IF OBJECT_ID('usp_Projects_update', 'P') IS NOT NULL
DROP PROC usp_Projects_update
GO

Create procedure usp_Projects_update
	@varId as nvarchar(50),
	@user as varchar(100),
	@Project nvarchar(255)  
	,@ProjectType nvarchar(100)  
	,@DocDate datetime  
	,@DocSource nvarchar(100)  
	,@Status nvarchar(100)  
	,@Barangay nvarchar(100)  
	,@District nvarchar(100)  
	,@Agency nvarchar(100)  
	,@Estimate money  
	,@ContractAmount money  
	,@Remarks nvarchar(max)  
	,@RoutedTo nvarchar(100)  
	,@startdate datetime  
	,@expirydate datetime  
	,@revisedexpirydate datetime  
	,@ammendedexpirydate datetime  

As

Update Projects Set Project = @Project 
		,ProjectType = @ProjectType 
		,DocDate = @DocDate 
		,DocSource = @DocSource 
		,Status = @Status 
		,Barangay = @Barangay 
		,District = @District 
		,Agency = @Agency 
		,Estimate = @Estimate 
		,ContractAmount = @ContractAmount 
		,Remarks = @Remarks 
		,RoutedTo = @RoutedTo 
		,startdate = @startdate 
		,expirydate = @expirydate 
		,revisedexpirydate = @revisedexpirydate 
		,ammendedexpirydate = @ammendedexpirydate 
		,updatedby = @user 
		,updateddate = getdate()
Where Id= @varId