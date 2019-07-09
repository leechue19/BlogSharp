USE MASTER
GO

IF EXISTS (SELECT * FROM sys.databases WHERE NAME = 'Blog')
BEGIN
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = 'Blog';
	ALTER DATABASE Blog SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE Blog;
END

CREATE DATABASE Blog;
GO
