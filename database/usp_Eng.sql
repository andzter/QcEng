
--select * from Communication 

IF OBJECT_ID('usp_CommunicationsSave', 'P') IS NOT NULL
	DROP PROC usp_CommunicationsSave
GO


CREATE procedure usp_CommunicationsSave   
    @id [nvarchar](50),
	@Project [nvarchar](1000),	
	@DocDate [Datetime],
	@DocSource [nvarchar](1000),	
	@remarks [nvarchar](max),
	@routeTo [varchar](50),
    @user [varchar](100)
AS
BEGIN
declare @commid  [nvarchar](50) = @id

declare @teamFrom varchar(50) 

	select top 1  @teamFrom = teamid from userteam t
	join users u on u.Id = t.userid
	  where userid = @user

 if isnull(@id,'') = ''
  begin

	declare @newid [nvarchar](50) = newId()
	    
	declare @refno varchar(50)
	declare @Refyr varchar(4) = 'REFNO-' +  cast(Year( getdate()) as varchar(4))
    exec usp_CodeSeq  @Refyr,'00000',@refno out 
    set @refno = cast(Year( getdate()) as varchar(4)) + '-' + @refno
 
   INSERT INTO [dbo].Communication
           (  id, ReferenceNo, [Project], [DocDate], [DocSource], [Status], Remarks, createdby, userFrom, [RouteFrom] )
   select @newid, @refno, @Project, @DocDate, @DocSource, 'New', @remarks, @user, @user, @teamFrom

   --select * from [ProjectsHistory]

  INSERT INTO [dbo].[ProjectsHistory]
           ([Id]
		   ,[CommId]
           ,[ProjectId]
		   ,[UserFrom]
           ,[RouteFrom]
           ,[RouteTo]
           ,[DateFrom]
           ,[RouteDate]
           ,[Status]
           ,[Remarks]
           ,[createdby])
     select newid(),@newid,'',@user,  @teamFrom, null, getdate(), null, 'NEW', @remarks, @user
           
   select @commid = @newid

  end
  else
  begin
	update  [dbo].Communication
	  set [Project] = @Project, DocSource = @DocSource, remarks = @remarks, updatedby = @user, updateddate = getdate(), RouteTo = @routeTo
	     , RouteFrom = @teamFrom
	     where id = @id
    declare @date datetime = getdate()
    select max([RouteDate]) from [ProjectsHistory] where [ProjectId] = @id
    INSERT INTO [dbo].[ProjectsHistory]
           ([Id]
		   , CommId
           ,[ProjectId]
		   ,UserFrom
           ,[RouteFrom]
           ,[RouteTo]
           ,[DateFrom]
           ,[RouteDate]
           ,[Status]
           ,[Remarks]
           ,[createdby])
     select newid(),@id,'', @user,  @teamFrom, @routeTo, isnull(@date, getdate()),  getdate(), 'NEW', @remarks, @user
  end

  select * from Communication where id = @commid

END
GO

IF OBJECT_ID('usp_CommunicationsGetList', 'P') IS NOT NULL
	DROP PROC usp_CommunicationsGetList
GO


CREATE procedure usp_CommunicationsGetList   
  @user varchar(50) 
AS
BEGIN
   select * from vw_CommunicationList
END
GO


IF OBJECT_ID('usp_CommunicationsGetbyId', 'P') IS NOT NULL
	DROP PROC usp_CommunicationsGetbyId
GO


CREATE procedure usp_CommunicationsGetbyId   
  @id varchar(50) 
AS
BEGIN
   select * from Communication where id = @id
END
GO


IF OBJECT_ID('usp_CommunicationsDelete', 'P') IS NOT NULL
	DROP PROC usp_CommunicationsDelete
GO


CREATE procedure usp_CommunicationsDelete   
  @id varchar(50),
  @user varchar(50)
AS
BEGIN
   select * from Communication
   update Communication
   set Deleted = 1,
      deleteddate = getdate(),
	  deletedby = @user
   where Id = @id
END
GO

--select * from Communication


IF OBJECT_ID('usp_CommunicationsHistory', 'P') IS NOT NULL
	DROP PROC usp_CommunicationsHistory
GO

CREATE procedure usp_CommunicationsHistory   
  @id  varchar(50),
  @user varchar(50) 
AS
BEGIN
    select   u1.UserName as [From], t1.Team as  [Route From]    , isnull(t2.Team, '') as [Route To],
		isnull(RouteDate, h.createdDate) as [Date], h.Remarks as comments, 
		DATEDIFF(day,  Isnull(DateFrom, h.createddate), Isnull(RouteDate, getdate()))    Days  
	from ProjectsHistory h
    left join Users u1 on h.UserFrom = u1.id
	left join Users u2 on h.RouteTo = u2.id
	left join Teams t1 on h.RouteFrom = t1.id
	left join Teams t2 on h.RouteTo = t2.id
     where h.CommId = @id
	 -- select * from ProjectsHistory 
END
GO


IF OBJECT_ID('usp_CommunicationsProject', 'P') IS NOT NULL
	DROP PROC usp_CommunicationsProject
GO


CREATE procedure [dbo].[usp_CommunicationsProject]  
   @commid varchar(50)
AS
BEGIN
  select Id, DEDNo, Project, Barangay, District from projects where CommId = @commid
END

GO
IF OBJECT_ID('usp_CommunicationsGetList', 'P') IS NOT NULL
	DROP PROC usp_CommunicationsGetList
GO
  

CREATE procedure [dbo].[usp_CommunicationsGetList]   
  @user varchar(50) 
AS
BEGIN
   select * from vw_CommunicationList
END
GO
 
IF OBJECT_ID('usp_GetMyTask', 'P') IS NOT NULL
	DROP PROC usp_GetMyTask
GO

CREATE procedure [dbo].[usp_GetMyTask]   
  @user varchar(50)
AS
BEGIN
  select Id,'Communication' as Type , ReferenceNo as [Number], Project as [Subject/Project], [Status] from Communication
     where RouteTo in (select teamid from userteam where userid =  @user)
  select Id,'Project'  as Type , DEDNo as [Number], Project as [Subject/Project], [Status] from Projects
     where RoutedTo in (select teamid from userteam where userid =  @user)
END
GO

IF OBJECT_ID('usp_GetProjectInspectionList', 'P') IS NOT NULL
	DROP PROC usp_GetProjectInspectionList
GO
 
CREATE procedure [dbo].[usp_GetProjectInspectionList]   
  @user varchar(50)
AS
BEGIN
  select p.Id, ReferenceNo, p.Project as [Subject], p.[Status] from Projects p
  join Communication c on c.Id = p.[CommId]
    -- where p.RoutedTo = @user or isnull(p.RoutedTo ,'') =''
END
GO

