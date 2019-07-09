USE Blog;
GO

--------------------------------------------------------
--Drop Tables-------------------------------------------
IF EXISTS(SELECT * FROM sys.tables WHERE NAME ='Users')
DROP TABLE Users
GO

IF EXISTS(SELECT * FROM sys.tables WHERE NAME ='Posts')
DROP TABLE Posts
GO

--------------------------------------------------------
--Users-------------------------------------------------
CREATE TABLE Users (
	UserId INT IDENTITY(1, 1) PRIMARY KEY,
	UserName VARCHAR(150) NOT NULL,
	[Password] VARCHAR(255) NOT NULL
);

--------------------------------------------------------
--Contacts----------------------------------------------
CREATE TABLE Post (
	PostId INT IDENTITY(1, 1) PRIMARY KEY,
	Title NVARCHAR(250) NOT NULL,
	[Message] NVARCHAR(MAX) NOT NULL,
	[Date] DATETIME NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users (UserId)
);
