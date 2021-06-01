IF OBJECT_ID('usp_Inspections_update', 'P') IS NOT NULL
DROP PROC usp_Inspections_update
GO

Create procedure usp_Inspections_update
		@user nvarchar(50)
		,@Id nvarchar(50)  
		,@Evaluation nvarchar(max)  
		,@Recommendations nvarchar(max)  
		,@InspectedBy nvarchar(100)  
		,@verifiedby nvarchar(100)  
		,@submittedby nvarchar(100)  
		,@TechnicalInsperctor1 nvarchar(100)  
		,@TechnicalInsperctor2 nvarchar(100)  
		,@TechnicalInsperctor3 nvarchar(100)  
		,@checkedby nvarchar(100)  
As

Update Instruction Set Evaluation = @Evaluation 
	,  Recommendations = @Recommendations 
	,  InspectedBy = @InspectedBy 
	,  verifiedby = @verifiedby 
	,  submittedby = @submittedby 
	,  TechnicalInsperctor1 = @TechnicalInsperctor1 
	,  TechnicalInsperctor2 = @TechnicalInsperctor2 
	,  TechnicalInsperctor3 = @TechnicalInsperctor3 
	,  checkedby = @checkedby 
	,  updatedby = @user 
	,  updateddate = getdate()
Where Id = @Id