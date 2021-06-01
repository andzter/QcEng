IF OBJECT_ID('usp_Users_view', 'P') IS NOT NULL
DROP PROC usp_Users_view
GO

Create procedure usp_Users_view
As

Select * From Users