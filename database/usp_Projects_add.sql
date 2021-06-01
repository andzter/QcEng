IF OBJECT_ID('usp_Projects_add', 'P') IS NOT NULL
DROP PROC usp_Projects_add
GO

Create Procedure usp_Projects_add
			@varProject nvarchar(255)
           ,@varProjectType nvarchar(100)
           ,@dtDocDate datetime
           ,@varDocSource nvarchar(100)
           ,@varStatus nvarchar(100)
           ,@varBarangay nvarchar(100)
           ,@varDistrict nvarchar(100)
           ,@varAgency nvarchar(100)
           ,@mnyEstimate money
           ,@mnyContractAmount money
           ,@varRemarks nvarchar(max)
           ,@varRoutedTo nvarchar(100)
           ,@dtstartdate datetime
           ,@dtexpirydate datetime
           ,@dtrevisedexpirydate datetime
           ,@dtammendedexpirydate datetime
           ,@varuser nvarchar(100)

As

begin

declare @refNo varchar(50) = (Select isnull(max(ReferenceNo),0) From Projects)
declare @refNum int = Cast(@refNo as int) + 1
print @refNo
print @refNum

declare @varReferenceNo varchar(50) = (

Select REPLICATE('0', 50 - LEN(@refNum)) + Cast(@refNum as nvarchar(50))

)

print @varReferenceNo

INSERT INTO [dbo].[Projects]
           ([Id]
           ,[ReferenceNo]
           ,[Project]
           ,[ProjectType]
           ,[DocDate]
           ,[DocSource]
           ,[Status]
           ,[Barangay]
           ,[District]
           ,[Agency]
           ,[Estimate]
           ,[ContractAmount]
           ,[Remarks]
           ,[RoutedTo]
           ,[startdate]
           ,[expirydate]
           ,[revisedexpirydate]
           ,[ammendedexpirydate]
           ,[createdby]
           ,[createddate]
           ,[updatedby]
           ,[updateddate])
     VALUES
           (newid()
           ,@varReferenceNo
           ,@varProject
           ,@varProjectType
           ,@dtDocDate
           ,@varDocSource
           ,@varStatus
           ,@varBarangay
           ,@varDistrict
           ,@varAgency
           ,@mnyEstimate
           ,@mnyContractAmount
           ,@varRemarks
           ,@varRoutedTo
           ,@dtstartdate
           ,@dtexpirydate
           ,@dtrevisedexpirydate
           ,@dtammendedexpirydate
           ,@varuser
           ,getdate()
           ,@varuser
           ,getdate())

end
GO


