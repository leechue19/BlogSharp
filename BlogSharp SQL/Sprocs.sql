USE Blog;
GO

-------------------------------------------------
--Select All Posts-------------------
IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SelectAllPosts')
   DROP PROCEDURE SelectAllPosts
GO
 
CREATE PROCEDURE SelectAllPosts
AS 
    SELECT *
	FROM Post;
GO

-------------------------------------------------
--Select Post By Id------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SelectPostById')
   DROP PROCEDURE SelectPostById
GO
 
CREATE PROCEDURE SelectPostById(
	@PostId INT
)
AS 
    SELECT *
	FROM Post
	WHERE PostId = @PostId;
GO

-------------------------------------------------
--Insert Post------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'InsertPost')
   DROP PROCEDURE InsertPost
GO
 
CREATE PROCEDURE InsertPost(
	@PostId INT, @Title NVARCHAR(250), @Message NVARCHAR(MAX), @Date DATETIME, @UserId INT
)
AS 
    INSERT INTO Post (Title, [Message], [Date], UserId) VALUES (@Title, @Message, @Date, @UserId);
GO

-------------------------------------------------
--Update Post------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'UpdatePost')
   DROP PROCEDURE UpdatePost
GO
 
CREATE PROCEDURE UpdatePost(
	@PostId INT, @Title NVARCHAR(250), @Message NVARCHAR(MAX), @Date DATETIME, @UserId INT
)
AS 
    UPDATE Post SET
	Title = @Title,
	[Message] = @Message,
	[Date] = @Date,
	UserId = @UserId
	WHERE PostId = @PostId;
GO

-------------------------------------------------
--Delete Post------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'DeletePost')
   DROP PROCEDURE DeletePost
GO
 
CREATE PROCEDURE DeletePost(
	@PostId INT
)
AS 
    DELETE FROM Post
	WHERE PostId = @PostId;
GO

-------------------------------------------------
--Select User By Id------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'SelectUserById')
   DROP PROCEDURE SelectUserById
GO
 
CREATE PROCEDURE SelectUserById(
	@UserId INT
)
AS 
    SELECT *
	FROM Post
	WHERE UserId = @UserId;
GO

-------------------------------------------------
--Insert User------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'InsertUser')
   DROP PROCEDURE InsertUser
GO
 
CREATE PROCEDURE InsertUser(
	@UserName VARCHAR(150), @Password VARCHAR(255)
)
AS 
    INSERT INTO Users (UserName, [Password]) VALUES (@UserName, @Password);
GO

-------------------------------------------------
--Update User------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'UpdateUser')
   DROP PROCEDURE UpdateUser
GO
 
CREATE PROCEDURE UpdateUser(
	@UserId INT, @UserName VARCHAR(150), @Password VARCHAR(255)
)
AS 
    UPDATE Users SET
	UserName = @UserName,
	[Password] = @Password
	WHERE UserId = @UserId;
GO

-------------------------------------------------
--Delete User------------------------------------
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_NAME = 'DeleteUser')
   DROP PROCEDURE DeleteUser
GO
 
CREATE PROCEDURE DeleteUser(
	@UserId INT
)
AS 
    DELETE FROM Users
    WHERE UserId = @UserId;
GO
