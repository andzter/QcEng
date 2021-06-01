IF OBJECT_ID('usp_Users_update', 'P') IS NOT NULL
DROP PROC usp_Users_update
GO

Create procedure usp_Users_update
	@user nvarchar(50)
	,@Id nvarchar(50)
	,@UserName nvarchar(20)
	,@Email nvarchar(200)
	,@Department nvarchar(200)
	,@Position nvarchar(200)
	,@Password varchar(25)
	,@Active bit
	,@isAdmin bit
As

Update Users Set UserName = @UserName 
			  ,  Email = @Email 
			  ,  Department = @Department 
			  ,  Position = @Position 
			  ,  Password = @Password 
			  ,  Active = @Active 
			  ,  isAdmin = @isAdmin 
			  ,  updatedby = @user 
			  ,  updateddate = getdate() 
Where Id=@Id
