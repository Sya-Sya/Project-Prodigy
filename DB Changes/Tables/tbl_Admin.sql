CREATE TABLE [dbo].[Admin] (
    [AdminId] INT IDENTITY(1,1) PRIMARY KEY,
    [FullName] VARCHAR(100) NOT NULL,
    [Username] VARCHAR(100) NOT NULL,
    [Email] VARCHAR(100) NOT NULL UNIQUE,
    [PasswordHash] VARCHAR(255) NOT NULL,
    [Role] VARCHAR(20) NOT NULL,
    [IsActive] BIT NOT NULL,  -- Changed to BIT for boolean logic
    [CreatedDate] DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    [LastLoginAt] DATE NULL
);
