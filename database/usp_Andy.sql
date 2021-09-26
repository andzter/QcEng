
IF OBJECT_ID('usp_CodeSeq', 'P') IS NOT NULL
	DROP PROC usp_CodeSeq
GO


CREATE procedure usp_ProjectSaveHeader   
  @id varchar(50),
  @Limits varchar(100),
  @Lenght varchar(100),
  @Appropriation varchar(1000),
  @Scopeofwork varchar(max),
  @DateEstimated datetime,
  @Rightofway varchar(100),
  @PavementWidth varchar(100),
  @SidewalkWidth varchar(100),
  @PavementType varchar(100),
  @Duration varchar(255)
AS
BEGIN 
 
UPDATE [dbo].[Projects]
   SET  [Limits] = @Limits
        ,[Lenght] = @Lenght
        ,[Appropriation] =  @Appropriation
        ,[Scopeofwork] = @Appropriation
        ,[DateEstimated] = @DateEstimated
        ,[Rightofway] = @Rightofway
        ,[PavementWidth] = @PavementWidth
        ,[SidewalkWidth] = @SidewalkWidth
        ,[PavementType] = @PavementType
        ,[Duration] = @Duration
   WHERE Id = @id

END
GO

select * from Users 



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


 
    
	 


update users set LastName = 'Verzosa, JR.', FirstName = 'Isagani', MiddleName = 'R.'
	where UserName = 'IRVJ'



update users set LastName = 'Del Rosario', FirstName = 'Leo', MiddleName = 'S.'
	where UserName = 'LBR'

truncate table projects

select * from projects
 

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
 


IF EXISTS (SELECT * FROM sysobjects WHERE  name = 'usp_teamslookup')
	BEGIN
		DROP Procedure usp_teamslookup
	END
GO


create procedure [dbo].usp_teamslookup
AS
BEGIN
   

SELECT [Id]  , team  FROM [dbo].[Teams]   order by displayseq

END

GO 
  
  

  select * from datatable