
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
  declare @commid  [nvarchar](50) = @id
  if isnull(@id,'') = ''
  begin

	declare @newid [nvarchar](50) = newId()

	declare @refno varchar(50)
	declare @Refyr varchar(4) = 'REFNO-' +  cast(Year( getdate()) as varchar(4))
    exec usp_CodeSeq  @Refyr,'00000',@refno out 
    set @refno = cast(Year( getdate()) as varchar(4)) + '-' + @refno


   INSERT INTO [dbo].Communication
           (  id, ReferenceNo, [Project], [DocDate], [DocSource], [Status], Remarks, createdby )
   select @newid, @refno, @Project, @DocDate, @DocSource, 'New', @remarks, @user

  -- select * from ProjectsHistory
    

  INSERT INTO [dbo].[ProjectsHistory]
           ([Id]
		   ,[CommId]
           ,[ProjectId]
           ,[RouteFrom]
           ,[RouteTo]
           ,[DateFrom]
           ,[RouteDate]
           ,[Status]
           ,[Remarks]
           ,[createdby])
     select newid(),@newid,'', @user, null, getdate(), null, 'NEW', @remarks, @user
           
   set  @newid

  end
  else
  begin
	update  [dbo].[Projects]
	  set [Project] = @Project, DocSource = @DocSource, remarks = @remarks, updatedby = @user, updateddate = getdate(), RoutedTo = @routeTo
	     where id = @id


   declare @date datetime = getdate()

  select max([RouteDate]) from [ProjectsHistory] where [ProjectId] = @id

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
     select newid(),@id, @user, @routeTo, isnull(@date, getdate()),  getdate(), 'NEW', @remarks, @user

    select @id
  end

END

GO