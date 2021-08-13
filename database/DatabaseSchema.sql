 
/****** Object:  Table [dbo].[Class]    Script Date: 5/24/2021 8:06:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO 

IF OBJECT_ID (N'Communication', N'U') IS NOT NULL 
   Drop table Communication
GO

CREATE TABLE [dbo].[Communication](
    [Id] [nvarchar](50),
	[ReferenceNo] [nvarchar](50),
	[Project] [nvarchar](1000),
	[DocDate] datetime,
	[DocSource] [nvarchar](1000) null,
	[Status] [nvarchar](100) null,
	[Barangay] [nvarchar](100) null,
	[District] [nvarchar](100) null,
	[Agency] [nvarchar](100) null,
	[Estimate] money default 0,
	[ContractAmount] money default 0,
	[Remarks] [nvarchar](max) null,
	[RouteFrom]  [nvarchar](100) null,
	[UserFrom]  [nvarchar](100) null,
	[RouteTo]  [nvarchar](100) null,
	[RouteUser]  [nvarchar](100) null,
	[startdate] datetime null, 
	[expirydate] datetime null, 
	[revisedexpirydate] datetime null, 
	[ammendedexpirydate] datetime null, 
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime null,
	[deletedby]  [nvarchar](100) null,
	[deleteddate]  datetime null	
) ON [PRIMARY]
GO 

IF OBJECT_ID (N'Projects', N'U') IS NOT NULL 
   Drop table Projects
GO

CREATE TABLE [dbo].[Projects](
    [Id] [nvarchar](50),
	[CommId] [nvarchar](50),
	[DEDNo] [nvarchar](50),
	[Project] [nvarchar](1000),
	[ProjectType] [nvarchar](100),
	[DocDate] datetime,
	[DocSource] [nvarchar](100) null,
	[Status] [nvarchar](100) null,
	[Barangay] [nvarchar](1000) null,
	[District] [nvarchar](100) null,
	[Agency] [nvarchar](100) null,
	[Estimate] money default 0,
	[ContractAmount] money default 0,
	[Remarks] [nvarchar](max) null,
	[RoutedTo]  [nvarchar](100) null,
	[RouteUser]  [nvarchar](100) null,
	[startdate] datetime null, 
	[expirydate] datetime null, 
	[revisedexpirydate] datetime null, 
	[ammendedexpirydate] datetime null, 
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime null,
	[deletedby]  [nvarchar](100) null,
	[deleteddate]  datetime null	
) ON [PRIMARY]
GO 

IF OBJECT_ID (N'ProjectsHistory', N'U') IS NOT NULL 
   Drop table ProjectsHistory
GO

CREATE TABLE [dbo].[ProjectsHistory](
    [Id] [nvarchar](50) default newid(),
	[CommId] [nvarchar](50),
	[ProjectId] [nvarchar](50) null,
	[RouteFrom] [nvarchar](50) null,
	[UserFrom] [nvarchar](50) null,
	[RouteTo] [nvarchar](50) null,
	[RouteUser]  [nvarchar](100) null,
	[DateFrom] datetime null,
	[DateTo] datetime null,
	[RouteDate] datetime default getdate(),
	[Status]  [nvarchar](100) null,
	[Remarks] [nvarchar](max) null,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime null
) ON [PRIMARY]
GO

IF OBJECT_ID (N'Folders', N'U') IS NOT NULL 
   Drop table Folders
GO

CREATE TABLE [dbo].[Folders](
    [Id] [nvarchar](50) default newid(),
	[FolderName] [nvarchar](max) null,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime null
) ON [PRIMARY]
GO 

IF OBJECT_ID (N'FolderFiles', N'U') IS NOT NULL 
   Drop table FolderFiles
GO

CREATE TABLE [dbo].[FolderFiles](
    [Id] [nvarchar](50) default newid(),
	[FileId] [nvarchar](50)
) ON [PRIMARY]
GO

IF OBJECT_ID (N'Files', N'U') IS NOT NULL 
   Drop table Files
GO

CREATE TABLE [dbo].[Files](
    [Id] [nvarchar](50) default newid(),
	[Path] [nvarchar](1000) null,
	[FileType] [nvarchar](100) null,
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime null,
	[deletedby]  [nvarchar](100) null,
	[deletedate] datetime null
	
) ON [PRIMARY]
GO

IF OBJECT_ID (N'FolderFiles', N'U') IS NOT NULL 
   Drop table FolderFiles
GO

CREATE TABLE [dbo].[FolderFiles](
    [Id] [nvarchar](50) default newid(),
	[FileId] [nvarchar](50)
) ON [PRIMARY]
GO

IF OBJECT_ID (N'Inspection', N'U') IS NOT NULL 
   Drop table Inspection
GO

CREATE TABLE [dbo].[Inspection](
    [Id] [nvarchar](50) default newid(),
	[CommId] [nvarchar](50),	
	Evaluation  [nvarchar](max) null,
	Recommendations [nvarchar](max) null,
	[InspectedBy] [nvarchar](100) null,
	[verifiedby] [nvarchar](100) null,
	[submittedby] [nvarchar](100) null,
	[TechnicalInsperctor1] [nvarchar](100) null,
	[TechnicalInsperctor2] [nvarchar](100) null,
	[TechnicalInsperctor3] [nvarchar](100) null,
	[checkedby] [nvarchar](100) null,
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime null,
	[deletedby]  [nvarchar](100) null,
	[deletedate] datetime null
) ON [PRIMARY]
GO


IF OBJECT_ID (N'InspectionDetails', N'U') IS NOT NULL 
   Drop table InspectionDetails
GO

CREATE TABLE [dbo].[InspectionDetails](
    [Id] [nvarchar](50) default newid(),
	Description  [nvarchar](max) null,
	Recommendations [nvarchar](max) null,
	[Seq] [int] null default 1, 
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime null
) ON [PRIMARY]
GO

IF OBJECT_ID (N'InspectionFiles', N'U') IS NOT NULL 
   Drop table InspectionFiles
GO

CREATE TABLE [dbo].[InspectionFiles](
    [Inspection] [nvarchar](50) default newid(),
	DetailsId [nvarchar](50),
	[FileId] [nvarchar](50),
	[Deleted] bit default 0,
    [createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[deletedby]  [nvarchar](100) null,
	[deletedate] datetime null
)


IF OBJECT_ID (N'RefLookUp', N'U') IS NOT NULL 
   Drop table RefLookUp
GO


CREATE TABLE [dbo].[RefLookUp](
    [Id] [nvarchar](50) default newid(),
	[Type] [nvarchar](100) null,
	[Code] [nvarchar](100) null,
	[Name] [nvarchar](255) null,
	[Seq] [int] NULL default 1,
	[CodeGroup] [nvarchar](100) NULL,
	[Active] [bit] NULL default 1,
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime default getdate(),
	[deletedby]  [nvarchar](100) null,
	[deletedate] datetime null

) ON [PRIMARY]
GO


--select * from RefLookUp


IF OBJECT_ID (N'Users', N'U') IS NOT NULL 
   drop table Users
GO

CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](50) NOT NULL default newid(),
	[UserName] [nvarchar](50) NULL,
	[LastName] [nvarchar](200) NULL,
	[FirstName] [nvarchar](200) NULL,
	[MiddleName] [nvarchar](100) NULL,
	[Email] [nvarchar](200) NULL,
	[Department] [nvarchar](100) NULL,
	[Position] [nvarchar](200) NULL,
	[Password] varbinary(100) NULL,
	[PasswordChange] [datetime] NULL,
	[PasswordTry] [int] NULL default 0,
	[Active] [bit] NULL default 1,
	[isAdmin] [bit] NULL default 0,
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime default getdate(),
	[deletedby]  [nvarchar](100) null,
	[deletedate] datetime null
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO  

IF OBJECT_ID (N'Teams', N'U') IS NOT NULL 
   drop table Teams
GO

CREATE TABLE [dbo].[Teams](
	[Id] [nvarchar](50) NOT NULL default newid(),
	[Team] [nvarchar](255) NOT NULL,
	[DisplaySeq] int default 0,
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime default getdate(),
	[deletedby]  [nvarchar](100) null,
	[deletedate] datetime null 
) ON [PRIMARY]

GO



IF OBJECT_ID (N'Roles', N'U') IS NOT NULL 
   drop table Roles
GO

CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](50) NOT NULL default newid(),
	[Role] [nvarchar](100) NOT NULL,
	[isSystem] bit default 0,
 CONSTRAINT [PK_dbo.Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

IF OBJECT_ID (N'UserTeam', N'U') IS NOT NULL 
   drop table UserTeams
GO

CREATE TABLE [dbo].[UserTeam](
    [Id] [nvarchar](50) NOT NULL default newid(),
	[UserId] [nvarchar](50) NOT NULL,
	[TeamId] [nvarchar](50) NOT NULL,
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime default getdate(),
	[deletedby]  [nvarchar](100) null,
	[deletedate] datetime null 
) ON [PRIMARY]

GO


IF OBJECT_ID (N'UserRoles', N'U') IS NOT NULL 
   drop table UserRoles
GO

CREATE TABLE [dbo].[UserRoles](
    [Id] [nvarchar](50) NOT NULL default newid(),
	[UserId] [nvarchar](50) NOT NULL,
	[RoleId] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO


IF OBJECT_ID (N'AppModules', N'U') IS NOT NULL 
   drop table AppModules
GO


CREATE TABLE [dbo].[AppModules](
    [Id] [nvarchar](50) NOT NULL default newid(),
	[Code] [nvarchar](100) NOT NULL,
	[ModuleName] [nvarchar](100) NULL,
) ON [PRIMARY]

IF OBJECT_ID (N'AppRoleModules', N'U') IS NOT NULL 
   drop table AppRoleModules
GO

CREATE TABLE [dbo].[AppRoleModules](
	[Id] [nvarchar](50) NOT NULL default newid(),
	[ModuleCode] varchar(25) NOT NULL,
	[RoleId] [nvarchar](50) NOT NULL,
	[Access] [bit] NULL default 1,
	[Write] [bit] NULL default 1
) ON [PRIMARY]

GO

IF OBJECT_ID (N'AppConfig', N'U') IS NOT NULL 
   drop table AppConfig
GO


CREATE TABLE [dbo].[AppConfig](
	[Id] [nvarchar](50) NOT NULL default newid(),
	[Code] nvarchar(100) NOT NULL,
	[Value] [nvarchar](255) NOT NULL
) ON [PRIMARY]

GO


IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'CodeSeq')
	BEGIN
		DROP  Table CodeSeq
	END
GO

CREATE TABLE CodeSeq
(
   [Code] varchar(50) null default '',
   [Seq] [int]
)  ON [PRIMARY]
GO
 

IF OBJECT_ID (N'ProjectEquipments', N'U') IS NOT NULL 
   Drop table ProjectEquipments
GO

CREATE TABLE [dbo].[ProjectEquipments](
    [Id] [nvarchar](50) default newid(),
	[ProjectId] [nvarchar](50),
	[Equipment] [nvarchar](500) null,
	[UnitNo] int null default 1,
	[Order] int null default 1, 
	[Remarks] [nvarchar](max) null,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime null
) ON [PRIMARY]
GO
 

IF OBJECT_ID (N'ProjectManpower', N'U') IS NOT NULL 
   Drop table ProjectManpower
GO

CREATE TABLE [dbo].[ProjectManpower](
    [Id] [nvarchar](50) default newid(),
	[ProjectId] [nvarchar](50),
	[Manpower] [nvarchar](500) null,
	[UnitNo] int null default 1,
	[Order] int null default 1, 
	[Remarks] [nvarchar](max) null,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime null
) ON [PRIMARY]
GO


IF OBJECT_ID (N'ProjectCertification', N'U') IS NOT NULL 
   Drop table ProjectCertification
GO

CREATE TABLE [dbo].[ProjectCertification](
    [Id] [nvarchar](50) default newid(),
	[ProjectId] [nvarchar](50),
	[IssuedOn] datetime default getdate(), 
	[IssuedBy] [nvarchar](100) null,
	[Remarks] [nvarchar](max) null,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime null
) ON [PRIMARY]
GO

IF OBJECT_ID (N'DUPA', N'U') IS NOT NULL 
   drop table DUPA
GO

CREATE TABLE [dbo].[DUPA](
	[Id] [nvarchar](50) NOT NULL default newid(),
	[ItemCode] varchar(200) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Unit] varchar(200) NOT NULL,
	[UnitCost] money default 0,
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime default getdate(),
	[deletedby]  [nvarchar](100) null,
	[deletedate] datetime null
) ON [PRIMARY]

GO

IF OBJECT_ID (N'DUPADerivation', N'U') IS NOT NULL 
   drop table DUPADerivation
GO

CREATE TABLE [dbo].[DUPADerivation](
	[Id] [nvarchar](50) NOT NULL default newid(),
	[ItemCode] varchar(200) NOT NULL,
	[Derivation] varchar(200) NOT NULL,
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime default getdate(),
	[deletedby]  [nvarchar](100) null,
	[deletedate] datetime null
) ON [PRIMARY]

GO


IF OBJECT_ID (N'ProjectBom', N'U') IS NOT NULL 
   drop table ProjectBom
GO

CREATE TABLE [dbo].[ProjectBom](
	[Id] [nvarchar](50) NOT NULL default newid(),
	[ProjectId] [nvarchar](50) NOT NULL,
	[ItemCode] varchar(200) NOT NULL,
	[Length] [nvarchar](100) null,
	[Width] [nvarchar](100) null,
	[Depth] [nvarchar](100) null,
	[Thickness] [nvarchar](100) null,
	[NumFactor1] [nvarchar](100) null,
	[NumFactor2] [nvarchar](100) null,
	[NumFactor3] [nvarchar](100) null,
	[ADLength] [nvarchar](100) null,
	[ADWidth] [nvarchar](100) null,
	[ADThickness] [nvarchar](100) null,
	[ADNoofUnits] [nvarchar](100) null,
	[SectionalArea] [nvarchar](100) null,
	[NoofUnits] [nvarchar](100) null,
	[WtMetricTon] [nvarchar](100) null,
	[Deleted] bit default 0,
	[createdby] [nvarchar](100) null,
	[createddate] datetime default getdate(), 
	[updatedby]  [nvarchar](100) null,
	[updateddate]  datetime default getdate(),
	[deletedby]  [nvarchar](100) null,
	[deletedate] datetime null
) ON [PRIMARY]

GO