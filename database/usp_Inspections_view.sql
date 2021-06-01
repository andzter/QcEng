IF OBJECT_ID('usp_Inspections_view', 'P') IS NOT NULL
DROP PROC usp_Inspections_view
GO

Create procedure usp_Inspections_view
	@user as varchar(100),
	@status as varchar(100)

As

Select * From Inspection