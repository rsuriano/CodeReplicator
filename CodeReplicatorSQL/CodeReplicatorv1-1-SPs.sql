USE [Genesis]
GO
/****** Object:  StoredProcedure [dbo].[CodeReplicator_GetTableNames]    Script Date: 12/3/2019 00:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CodeReplicator_GetTableNames] AS
BEGIN
SELECT name
FROM sys.TABLES
END


/****** Object:  StoredProcedure [dbo].[CodeReplicator_GetSPs]    Script Date: 12/3/2019 00:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CodeReplicator_GetSPs] AS
BEGIN
SELECT ROUTINE_NAME FROM Genesis.information_schema.routines WHERE routine_type = 'PROCEDURE'
END


/****** Object:  StoredProcedure [dbo].[CodeReplicator_GetParameters]    Script Date: 12/3/2019 00:40:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CodeReplicator_GetParameters] @ProcName varchar(50) AS
BEGIN
SELECT  
	'ParameterName' = name,  
	'Type'   = type_name(user_type_id),  
	'Length'   = max_length

FROM sys.parameters WHERE object_id = object_id(@ProcName)
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CodeReplicator_GetTableInfo] @TableName varchar(50) AS
BEGIN
SELECT	col.name AS ColName, 
		t.name AS DataType,    
		col.max_length AS Length
FROM sys.tables AS tab
    inner join sys.columns AS col
        ON tab.object_id = col.object_id
    left join sys.types AS t
    ON col.user_type_id = t.user_type_id
WHERE tab.name = @TableName
END