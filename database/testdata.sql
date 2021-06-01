

if not exists(select 1 from AppConfig where code = 'DEFAULTPASSWORD')
insert into AppConfig (Code, Value) select 'DEFAULTPASSWORD','P@ssword123'
GO

if not exists(select 1 from AppConfig where code = 'PASSWORDKEY')
	insert into AppConfig (Code, Value) select 'PASSWORDKEY','ENGQC_PASS_KEY'
GO
 
 
 truncate table Roles

insert into Roles 
  ([Role], [isSystem])
	  select 'DIVISIONHEAD', 1
union select 'DEPARMENTHEAD', 1
union select 'SECTIONHEAD', 1
union select 'TEAMLEAD', 1
union select 'INSPECTOR', 1
union select 'ENGINEER', 1


select * from Roles


select * from userroles



select EncryptByPassPhrase(Value, 'Jothish' )   from AppConfig 
   where code = 'PASSWORDKEY'

--select * from AppConfig


declare @Defaultpass varchar(100) = ''
 select @Defaultpass = value from AppConfig where code = 'DEFAULTPASSWORD'

 truncate table users

insert into users (username,  password)
	select 'IRVJ', EncryptByPassPhrase(Value, @Defaultpass )   from AppConfig
		where code = 'PASSWORDKEY'
union  
	select 'LBR', EncryptByPassPhrase(Value, @Defaultpass )   from AppConfig
		where code = 'PASSWORDKEY'
union  
	select 'FDLDG', EncryptByPassPhrase(Value, @Defaultpass )   from AppConfig
		where code = 'PASSWORDKEY'
union  
	select 'TEAMLEAD1', EncryptByPassPhrase(Value, @Defaultpass )   from AppConfig
		where code = 'PASSWORDKEY'
union  
	select 'TEAMLEAD2', EncryptByPassPhrase(Value, @Defaultpass )   from AppConfig
		where code = 'PASSWORDKEY'
union  
	select 'TEAMLEAD3', EncryptByPassPhrase(Value, @Defaultpass )   from AppConfig
		where code = 'PASSWORDKEY'
union  
	select 'TEAMLEAD4', EncryptByPassPhrase(Value, @Defaultpass )   from AppConfig
		where code = 'PASSWORDKEY'
union  
	select 'TEAMLEAD5', EncryptByPassPhrase(Value, @Defaultpass )   from AppConfig
		where code = 'PASSWORDKEY'


TRUNCATE TABLE UserRoles

DECLARE @ID VARCHAR(50)
SElect @ID = ID FROM Roles WHERE role = 'DEPARMENTHEAD'
-- SELECT * FROM UserRoles

INSERT INTO UserRoles(USERID, ROLEID)
SELECT ID, @ID FROM users WHERE username = 'IRVJ'

SElect @ID = ID FROM Roles WHERE role = 'DIVISIONHEAD'
INSERT INTO UserRoles(USERID, ROLEID)
SELECT ID, @ID FROM users WHERE username = 'LBR'

SElect @ID = ID FROM Roles WHERE role = 'SECTIONHEAD'
INSERT INTO UserRoles(USERID, ROLEID)
SELECT ID, @ID FROM users WHERE username = 'FDLDG'

SElect @ID = ID FROM Roles WHERE role = 'TEAMLEAD'
INSERT INTO UserRoles(USERID, ROLEID)
SELECT ID, @ID FROM users WHERE username LIKE  'TEAM%'

-- truncate table  AppConfig
--

declare @pass varchar(100) = 'P@ssword123'
   
select * from users
  where  convert( varchar(100), DecryptByPassPhrase('ENGQC_PASS_KEY',password)) = @pass


  select * from users
exec usp_Login_user 'USER1', 'P@ssword123'




