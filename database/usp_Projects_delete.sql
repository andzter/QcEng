IF OBJECT_ID('usp_Projects_delete', 'P') IS NOT NULL
DROP PROC usp_Projects_delete
GO

Create procedure usp_Projects_delete
	@varId as nvarchar(50),
	@user as varchar(100)

As

Update Projects Set Deleted=1,deletedby=@user,deleteddate=getdate()
Where Id=@varId