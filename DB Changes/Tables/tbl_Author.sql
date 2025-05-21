CREATE TABLE [dbo].[Authors] (
    [AuthorID] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL,
    [Bio] NVARCHAR(MAX) NULL,
    [Country] VARCHAR(50) NULL,
	[IsDeleted] VARCHAR(5) NULL,
	[IsBlocked] VARCHAR(5) NULL,
    [DateOfBirth] DATE NULL
);
