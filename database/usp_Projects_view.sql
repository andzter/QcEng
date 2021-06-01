IF OBJECT_ID('usp_Projects_view', 'P') IS NOT NULL
DROP PROC usp_Projects_view
GO

Create procedure usp_Projects_view
	@user as varchar(100),
	@status as varchar(100)

As

Select * From Projects