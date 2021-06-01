IF OBJECT_ID('usp_Inspections_delete', 'P') IS NOT NULL
DROP PROC usp_Inspections_delete
GO

Create procedure usp_Inspections_delete
	@varId as nvarchar(50),
	@user as varchar(100)

As

Update Inspection Set Deleted=1,deletedby=@user,deletedate=getdate()
Where Id=@varId