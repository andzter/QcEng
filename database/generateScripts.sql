 use test

declare @TableName varchar(100) = 'Files'

declare @sql varchar(max) = 'Create procedure usp_save' + @TableName
declare @tmp varchar(max) = ''

	SELECT    STUFF((SELECT    ',' + '@' + c.name + ' ' + tp.name + 
	                                        case
											when  tp.name = 'nvarchar'
												 then '(' + cast(c.max_length/2  as varchar(10)) + ')'
											 when  tp.name = 'varchar'
													  then '(' + cast(c.max_length/2  as varchar(10)) + ')'
												else ''
										  end
										  + '|'
						FROM sys.columns c
							join sys.tables t on c.object_id = t.object_id
							join sys.types tp on c.system_type_id = tp.system_type_id 
						WHERE t.OBJECT_ID = OBJECT_ID(@TableName)
						  and tp.name <> 'sysname'
						order by c.column_id 
				FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)') 
			,1,1,'')


			
	SELECT    STUFF((SELECT    ',' + '@' + replace(c.name  ,' ','')
	                                        
						FROM sys.columns c
							join sys.tables t on c.object_id = t.object_id
							join sys.types tp on c.system_type_id = tp.system_type_id 
						WHERE t.OBJECT_ID = OBJECT_ID(@TableName)
						  and tp.name <> 'sysname'
						order by c.column_id 
				FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)') 
			,1,1,'')


select @sql = @sql + @tmp

select @sql

SELECT  STUFF((SELECT   ',' + QUOTENAME(c.name) 
						FROM sys.columns c
							join sys.tables t on c.object_id = t.object_id
							join sys.types tp on c.system_type_id = tp.system_type_id 
						WHERE t.OBJECT_ID = OBJECT_ID(@TableName)
						 and c.column_id <> 1 
						 and tp.name <> 'sysname'
						 Order by c.column_id
				FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)') 
			,1,1,'')


SELECT * FROM sys.objects WHERE type = 'P' AND name = 'usp_saveAirport'


SELECT  STUFF((SELECT   ',  ' + c.name + ' = @' + c.name + char(13)
						FROM sys.columns c
							join sys.tables t on c.object_id = t.object_id
							join sys.types tp on c.system_type_id = tp.system_type_id 
						WHERE t.OBJECT_ID = OBJECT_ID(@TableName)
						 and c.column_id <> 1 
						 and tp.name <> 'sysname'
						 Order by c.column_id
				FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)') 
			,1,1,'')


	SELECT    STUFF((SELECT  ',' + '@' + c.name + ' ' + tp.name + 
	                                        case
											when  tp.name = 'nvarchar'
												 then '(' + cast(c.max_length/2  as varchar(10)) + ')'
											 when  tp.name = 'varchar'
													  then '(' + cast(c.max_length/2  as varchar(10)) + ')'
												else ''
										  end
										  + char(10) +char(13)
						FROM sys.columns c
							join sys.tables t on c.object_id = t.object_id
							join sys.types tp on c.system_type_id = tp.system_type_id 
						WHERE t.OBJECT_ID = OBJECT_ID(@TableName)
						  and tp.name <> 'sysname'
						order by c.column_id 
				FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)') 
			,1,1,'')


			SELECT    STUFF((SELECT  ',' + 'columns.Bound(p => p.' + c.name + ')' +
	                                        case
											when  tp.name = 'datetime'
												 then '.Format("{0:MM/dd/yyyy}").Width(120)'
												else '.Width(100)'
										  end
										  + ';' 
						FROM sys.columns c
							join sys.tables t on c.object_id = t.object_id
							join sys.types tp on c.system_type_id = tp.system_type_id 
						WHERE t.OBJECT_ID = OBJECT_ID(@TableName)
						  and tp.name <> 'sysname'
						order by c.column_id 
				FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)') 
			,1,1,'')


			SELECT    STUFF((SELECT  ',' + '<div class="editor-label">@Html.LabelFor(model => model.' + c.name + ')</div>'                    
						  + ',<div class="editor-field">@Html.EditorFor(model => model.' + c.name + ')</div>'
						FROM sys.columns c
							join sys.tables t on c.object_id = t.object_id
							join sys.types tp on c.system_type_id = tp.system_type_id 
						WHERE t.OBJECT_ID = OBJECT_ID(@TableName)
						  and tp.name <> 'sysname'
						  and c.name not in ('FiscalYear','CreateDate','CreatedBy','UpdateDate','UpdatedBy')
						order by c.column_id 
				FOR XML PATH(''), TYPE
				).value('.', 'NVARCHAR(MAX)') 
			,1,1,'')



--Id nvarchar(50)|,@Path nvarchar(1000)|,@FileType nvarchar(100)|,@Deleted bit|,@createdby nvarchar(100)|,@createddate datetime|,@updatedby nvarchar(100)|,@updateddate datetime|,@deletedate datetime|
--			Create procedure usp_saveFiles




