 

/****** Object:  Table [dbo].[Class]    Script Date: 5/24/2021 8:06:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID (N'Projects', N'U') IS NOT NULL 
   Drop table Projects
GO 


select * from Users

select Manpower, UnitNo [No. Of Unit] from [ProjectManpower]
select Equipment [Name of Equipment], UnitNo [No. Of Unit] from [ProjectEquipments]

select * from [ProjectEquipments]

insert into [ProjectManpower] (ProjectId, Manpower, UnitNo)
  select '1','Project Manager', 1
union  select '1','ProjectEngineer', 1
union  select '1','Equipment Operator', 1


insert into [ProjectEquipments] (ProjectId, Equipment, UnitNo)
  select '1','Jackhammer', 1
union  select '1','Truck', 1
union  select '1','Payloader', 1


declare @refno varchar(50)
declare @Refyr varchar(4) = 'REFNO-' +  cast(Year( getdate()) as varchar(4))
       exec usp_CodeSeq  @Refyr,'00000',@refno out 
	   select cast(Year( getdate()) as varchar(4)) + '-' + @refno



	   