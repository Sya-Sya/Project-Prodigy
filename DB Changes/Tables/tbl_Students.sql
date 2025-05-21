CREATE TABLE [dbo].[Student] (
    [StudentId] INT IDENTITY(1,1) PRIMARY KEY,
    [FullName] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) UNIQUE NOT NULL,
	[IsDeleted] VARCHAR(5) NULL,
	[IsBlocked] VARCHAR(5) NULL,
    [EnrollmentDate] DATE NOT NULL
);

INSERT INTO Student (FullName, Email, EnrollmentDate)
VALUES (
    'SHINIGAMI',
    'prashant.shreatha69@example.com',
    '2000-03-15'
);

SELECT 
    SUSER_NAME() AS LoggedInUser,
    HOST_NAME() AS ClientMachine,
    APP_NAME() AS ApplicationName,
    @@SERVERNAME AS ServerName,
    DB_NAME() AS CurrentDatabase;
