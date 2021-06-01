IF OBJECT_ID('usp_Inspections_add', 'P') IS NOT NULL
DROP PROC usp_Inspections_add
GO

Create Procedure usp_Inspections_add
		@user nvarchar(50)
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

Insert Into Inspection (
			[Evaluation]
			,[Recommendations]
			,[InspectedBy]
			,[verifiedby]
			,[submittedby]
			,[TechnicalInsperctor1]
			,[TechnicalInsperctor2]
			,[TechnicalInsperctor3]
			,[checkedby]
			,[createdby]
			,[createddate]
)
Values (
		@Evaluation
		,@Recommendations
		,@InspectedBy
		,@verifiedby
		,@submittedby
		,@TechnicalInsperctor1
		,@TechnicalInsperctor2
		,@TechnicalInsperctor3
		,@checkedby
		,@user
		,getdate()
)