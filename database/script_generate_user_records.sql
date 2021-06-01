insert into Users(Username,Email,Department,Position)
select 'User1','user1@gmail.com','Engineering','Department Head'
union 
Select 'User2','user2@gmail.com','Engineering','Division Head'
union
select 'User3','user3@gmail.com','Engineering','Section Head'
union
select 'User4','user4@gmail.com','Engineering','Inspector'
union
select 'User5','user5@gmail.com','Engineering','Engineer'

select * from users
 