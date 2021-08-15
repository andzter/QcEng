IF OBJECT_ID('usp_GetMyTask', 'P') IS NOT NULL
	DROP PROC usp_GetMyTask
GO


CREATE procedure [dbo].[usp_GetMyTask]   
  @user varchar(50)
AS
BEGIN
  select Id,'Communication' as Type , ReferenceNo as [Number], Project as [Subject/Project], [Status] from Communication
     where RoutedTo = @user
  select Id,'Project'  as Type , DEDNo as [Number], Project as [Subject/Project], [Status] from Projects
     where RoutedTo = @user
END
GO






IF OBJECT_ID('usp_ProjectSaveNew', 'P') IS NOT NULL
	DROP PROC usp_ProjectSaveNew
GO


CREATE procedure [dbo].[usp_ProjectSaveNew]   
  @commid varchar(50),
  @project varchar(1000),
  @barangay varchar(1000),
  @district varchar(100),
  @remarks varchar(max),
  @RoutedTo varchar(50),
  @user varchar(50)
AS
BEGIN
	declare @newid [nvarchar](50) = newId()
	declare @refno varchar(50)
	declare @Refyr varchar(4) = 'DEDNO-' +  cast(Year( getdate()) as varchar(4))
    exec usp_CodeSeq  @Refyr,'00000',@refno out 
    set @refno = 'DED-' + cast(Year( getdate()) as varchar(4)) + '-' + @refno
 INSERT INTO [dbo].[Projects]
           ([Id]   ,[CommId]  ,[DEDNo]      ,[Project]  ,[DocDate]  ,[Status]  ,[Barangay] ,[District],[Remarks],[RoutedTo] ,[createdby] )
select @newid ,@commid  ,@refno, @project  ,getdate()  ,'New'  ,@barangay ,@district,@remarks,@RoutedTo ,@user 

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
     select newid(),@commid, @newid, @user, @RoutedTo, getdate(), getdate(), 'NEW', @remarks, @user

	 select @newid

END
GO  
 

IF OBJECT_ID('usp_ProjectDesignList', 'P') IS NOT NULL
	DROP PROC usp_ProjectDesignList
GO

CREATE procedure [dbo].[usp_ProjectDesignList]   
  @user varchar(50)
AS
BEGIN
 
 select * from projects

END

GO