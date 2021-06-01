
IF OBJECT_ID('usp_Login_user', 'P') IS NOT NULL
DROP PROC usp_Login_user
GO

Create procedure usp_Login_user
	@user as varchar(100),
	@password as varchar(100)

As
   declare @id varchar(50) = ''
   
   declare @PassPhrase varchar(100) = ''
   
   select @PassPhrase = value from AppConfig where code = 'PASSWORDKEY'

select @id = id  from users
  where convert( varchar(100), DecryptByPassPhrase(@PassPhrase,password)) = @password
    and username = @user


  Select isnull(@id,'')
GO
