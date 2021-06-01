IF OBJECT_ID('usp_Users_delete', 'P') IS NOT NULL
DROP PROC usp_Users_delete
GO

Create procedure usp_Users_delete
	@Id as varchar(50)
As

Update Users Set Deleted = 1, Deletedate = getdate()
Where Id=@Id