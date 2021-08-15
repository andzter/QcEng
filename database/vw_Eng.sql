

IF OBJECT_ID('vw_userlookup', 'V') IS NOT NULL
	DROP View vw_userlookup
GO

create view vw_userlookup
AS

  select id, isnull( Firstname + ' ' +   middlename + ' ' + LastName , username) as [User] from users  
GO
   

IF EXISTS (SELECT * FROM sysobjects WHERE  name = 'vw_projectbom')
	BEGIN
		DROP View vw_projectbom
	END
GO


CREATE VIEW [dbo].[vw_projectbom]
AS
select a.ProjectId, 
       a.ItemCode as [Item Code], 
	   b.Description,
	   b.Unit,
	   c.Derivation, 
	   a.Length, 
	   a.Width, 
	   a.Depth,
	   a.Thickness,
	   a.NumFactor1 as [Factor 1],
	   a.NumFactor2 as [Factor 2],
	   a.NumFactor3 as [Factor 3],
	   a.ADLength as [AD Length],
	   a.ADWidth as [AD Width],
	   a.ADThickness as [AD Thickness],
	   a.ADNoofUnits as [AD No of Units],
	   a.SectionalArea as [Sectional Area],
       a.NoofUnits as [No of Units],
	   a.WtMetricTon as [Wt Metric Ton],
	   NULL as [Total Length],
	   NULL as [Volume],
	   NULL as [Area]
from ProjectBom a
left join dupa b on
   a.itemcode=b.itemcode
left join dupaderivation c on
   a.itemcode =c.itemcode

GO



IF EXISTS (SELECT * FROM sysobjects WHERE  name = 'vw_Communication')
	BEGIN
		DROP View vw_Communication
	END
GO
  
CREATE VIEW [dbo].vw_Communication
AS 

SELECT [Id]  ,[ReferenceNo] ,[Project] ,[DocDate] ,[DocSource] ,[Status],[Barangay]  ,[District] ,[Agency]  ,[Estimate]
      ,[ContractAmount]  ,[Remarks] ,[RoutedTo]
  FROM [dbo].[Communication]

GO

IF EXISTS (SELECT * FROM sysobjects WHERE  name = 'vw_CommunicationList')
	BEGIN
		DROP View vw_CommunicationList
	END
GO
  
CREATE VIEW [dbo].vw_CommunicationList
AS 

SELECT [Id]  ,[ReferenceNo] ,[Project] as Subject ,[DocDate] ,[DocSource] ,[Status],[Barangay]  ,[District] ,[Agency]  ,[Estimate]
      ,[ContractAmount]  ,[Remarks] ,[RouteTo]
  FROM [dbo].[Communication]

GO


IF EXISTS (SELECT * FROM sysobjects WHERE  name = 'vw_teamslookup')
	BEGIN
		DROP View vw_teamslookup
	END
GO
  
CREATE VIEW [dbo].vw_teamslookup
AS 

SELECT [Id]  , team  FROM [dbo].[Teams]   order by displayseq

GO
 


select * from users 