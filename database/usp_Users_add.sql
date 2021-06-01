IF OBJECT_ID('usp_Users_add', 'P') IS NOT NULL
DROP PROC usp_Users_add
GO

Create Procedure usp_Users_add
	@UserName nvarchar(20)
	,@Email nvarchar(200)
	,@Department nvarchar(200)
	,@Position nvarchar(200)
	,@Password varchar(25)
	,@isAdmin bit
As

Insert Into Users (
			[UserName]
			,[Email]
			,[Department]
			,[Position]
			,[Password]
			,[isAdmin]	
)

Values (@UserName
		,@Email
		,@Department
		,@Position
		,@Password
		,@isAdmin
		)

