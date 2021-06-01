
IF EXISTS (SELECT * FROM sysobjects WHERE  name = 'usp_ProjectGetbyId')
	BEGIN
		DROP Procedure usp_ProjectGetbyId
	END
GO

create procedure [dbo].usp_ProjectGetbyId
    @id [nvarchar](50)
AS
BEGIN
  
  select * from  Projects where id = @id

END