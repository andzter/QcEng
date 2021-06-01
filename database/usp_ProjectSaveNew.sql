
IF EXISTS (SELECT * FROM sysobjects WHERE  name = 'usp_ProjectSaveNew')
	BEGIN
		DROP Procedure usp_ProjectSaveNew
	END
GO

create procedure [dbo].usp_ProjectSaveNew
    @id [nvarchar](50),
	@Project [nvarchar](255),	
	@DocDate [Datetime],
	@DocSource [nvarchar](100),	
	@remarks [nvarchar](max),
	@routeTo [varchar](50),
    @user [varchar](100)
AS
BEGIN
  
  if isnull(@id,'') = ''
  begin

	declare @newid [nvarchar](50) = newId()

	declare @refno varchar(50)
       exec usp_CodeSeq 'REF','00000',@refno out 


   INSERT INTO [dbo].[Projects]
           (  id, ReferenceNo, [Project], [DocDate], [DocSource], [Status], Remarks, createdby )
   select @newid, @refno, @Project, @DocDate, @DocSource, 'New', @remarks, @user

  -- select * from ProjectsHistory
    

  INSERT INTO [dbo].[ProjectsHistory]
           ([Id]
           ,[ProjectId]
           ,[RouteFrom]
           ,[RouteTo]
           ,[DateFrom]
           ,[RouteDate]
           ,[Status]
           ,[Remarks]
           ,[createdby])
     select newid(),@newid, @user, null, getdate(), null, 'NEW', @remarks, @user
           
   select @newid

  end
  else
  begin
	update  [dbo].[Projects]
	  set [Project] = @Project, DocSource = @DocSource, remarks = @remarks, updatedby = @user, updateddate = getdate(), RoutedTo = @routeTo
	     where id = @id

  INSERT INTO [dbo].[ProjectsHistory]
           ([Id]
           ,[ProjectId]
           ,[RouteFrom]
           ,[RouteTo]
           ,[DateFrom]
           ,[RouteDate]
           ,[Status]
           ,[Remarks]
           ,[createdby])
     select newid(),@id, @user, @routeTo, getdate(), null, 'NEW', @remarks, @user

    select @id
  end

END

GO