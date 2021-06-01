
IF OBJECT_ID('usp_CodeSeq', 'P') IS NOT NULL
	DROP PROC usp_CodeSeq
GO


CREATE procedure usp_CodeSeq   
  @code varchar(50), 
  @pad varchar(20),
  @nextseq varchar(20) output
AS
BEGIN
set @nextseq = ''
declare @seq int

select @seq = count(seq) from CodeSeq where Code = @code

if @seq = 0
begin
   insert into CodeSeq(code,seq) select @code,2
   set @seq = 1
end
else
begin
   select @seq = seq from CodeSeq where Code = @code   
   update CodeSeq set seq = seq + 1 where Code = @code   
end

if len(@pad) = 0
  set @nextseq = cast(@seq as varchar(20))
else
  set @nextseq =reverse(substring(reverse(@pad + cast(@seq as varchar(20))),1,len(@pad)))
END
GO



IF OBJECT_ID('usp_GetCommProject', 'P') IS NOT NULL
	DROP PROC usp_GetCommProject
GO


CREATE procedure usp_GetCommProject   
  @user varchar(50)
AS
BEGIN
  select * from Projects
     where status = 'NEW'
END
GO 

IF OBJECT_ID('usp_GetMyProject', 'P') IS NOT NULL
	DROP PROC usp_GetMyProject
GO


CREATE procedure usp_GetMyProject   
  @user varchar(50)
AS
BEGIN
  select Id, ReferenceNo, Project as [Subject], [Status] from Projects
     where RoutedTo = @user
END
GO



IF OBJECT_ID('usp_ProjectDesignList', 'P') IS NOT NULL
	DROP PROC usp_ProjectDesignList
GO


CREATE procedure usp_ProjectDesignList   
  @user varchar(50)
AS
BEGIN
  select Id, ReferenceNo, Project as [Subject], [Status] from Projects
     where RoutedTo = @user  or isnull(RoutedTo ,'') =''
END
GO


IF OBJECT_ID('usp_ProjectFolderList', 'P') IS NOT NULL
	DROP PROC usp_ProjectFolderList
GO


CREATE procedure usp_ProjectFolderList   
  @user varchar(50)
AS
BEGIN
  select Id, ReferenceNo, Project as [Subject], [Status] from Projects
     where RoutedTo = @user  or isnull(RoutedTo ,'') =''
END
GO



IF OBJECT_ID('GetProjectInspectionList', 'P') IS NOT NULL
	DROP PROC GetProjectInspectionList
GO


CREATE procedure GetProjectInspectionList   
  @user varchar(50)
AS
BEGIN
  select Id, ReferenceNo, Project as [Subject], [Status] from Projects
     where RoutedTo = @user or isnull(RoutedTo ,'') =''
END
GO



IF OBJECT_ID('usp_ProjectSaveRoute', 'P') IS NOT NULL
	DROP PROC usp_ProjectSaveRoute
GO


CREATE procedure usp_ProjectSaveRoute   
  @projectId varchar(50),
  @user varchar(50),
  @routeTo varchar(50),
  @comments  varchar(max)
AS
BEGIN
 

INSERT INTO [dbo].[ProjectsHistory]
           ( [ProjectId]
           ,[RouteFrom]
           ,[RouteTo]
           ,[RouteDate]
           ,[Remarks]
           ,[createdby])
          select @projectId, @user, @routeTo, getdate(), @comments, @user

END
GO

IF OBJECT_ID('GetProjectHistory', 'P') IS NOT NULL
	DROP PROC GetProjectHistory
GO


CREATE procedure GetProjectHistory   
  @id varchar(50)
AS
BEGIN
  select u1.UserName as RouteFrom    , isnull(u2.UserName, '') as [Route To], isnull(RouteDate, h.createdDate) as [Date], h.Remarks as comments, 
    DATEDIFF(day,  Isnull(DateFrom, h.createddate), Isnull(RouteDate, getdate()))    Days  from ProjectsHistory h
    left join Users u1 on h.RouteFrom = u1.id
	left join Users u2 on h.RouteTo = u2.id
     where h.ProjectId = @id
END
GO


select * from ProjectsHistory



IF OBJECT_ID('vw_userlookup', 'V') IS NOT NULL
	DROP View vw_userlookup
GO

create view vw_userlookup
AS

  select id, isnull( Firstname + ' ' +   middlename + ' ' + LastName , username) as [User] from users  
GO
   

select * from users
  


update users set LastName = 'Verzosa, JR.', FirstName = 'Isagani', MiddleName = 'R.'
	where UserName = 'IRVJ'



update users set LastName = 'Del Rosario', FirstName = 'Leo', MiddleName = 'S.'
	where UserName = 'LBR'

truncate table projects

select * from projects
 
IF EXISTS (SELECT * FROM sysobjects WHERE  name = 'vw_projectbom')
	BEGIN
		DROP View vw_projectbom
	END
GO


CREATE VIEW [dbo].[vw_projectbom]
AS
select a.ProjectId, 
       a.ItemCode as [Item Code], 
	   b.Description,
	   b.Unit,
	   c.Derivation, 
	   a.Length, 
	   a.Width, 
	   a.Depth,
	   a.Thickness,
	   a.NumFactor1 as [Factor 1],
	   a.NumFactor2 as [Factor 2],
	   a.NumFactor3 as [Factor 3],
	   a.ADLength as [AD Length],
	   a.ADWidth as [AD Width],
	   a.ADThickness as [AD Thickness],
	   a.ADNoofUnits as [AD No of Units],
	   a.SectionalArea as [Sectional Area],
       a.NoofUnits as [No of Units],
	   a.WtMetricTon as [Wt Metric Ton],
	   NULL as [Total Length],
	   NULL as [Volume],
	   NULL as [Area]
from ProjectBom a
left join dupa b on
   a.itemcode=b.itemcode
left join dupaderivation c on
   a.itemcode =c.itemcode

GO


IF EXISTS (SELECT * FROM sysobjects WHERE  name = 'usp_ProjectBomGetbyId')
	BEGIN
		DROP Procedure usp_ProjectBomGetbyId
	END
GO

create procedure [dbo].usp_ProjectBomGetbyId
    @id [nvarchar](50)
AS
BEGIN
  
  select * from  ProjectBom where ProjectId = @id

END


IF EXISTS (SELECT * FROM sysobjects WHERE  name = 'usp_DUPASaveNew')
	BEGIN
		DROP Procedure usp_DUPASaveNew
	END
GO

create procedure [dbo].usp_DUPASaveNew
    @id [nvarchar](50),
	@ItemCode [nvarchar](200),
	@Description [nvarchar](200),
	@Unit [nvarchar](200),
	@UnitCost [money],
	@User [nvarchar](100)
AS
BEGIN
  
  if isnull(@id,'') = ''
  begin

	declare @newid [nvarchar](50) = newId()

   INSERT INTO [dbo].[DUPA]
           (  id, ItemCode, Description,Unit,UnitCost,createdby )
   select @newid, @ItemCode,@Description,@Unit,@UnitCost,@user
           
   select @newid
  end
  else
  begin
	update  [dbo].[DUPA]
	  set   ItemCode = @ItemCode,Description = @Description,Unit = @Unit,UnitCost = @UnitCost
			,updatedby = @User, updateddate = getdate() 
	     where id = @id
    select @id
  end

END

GO
 

  