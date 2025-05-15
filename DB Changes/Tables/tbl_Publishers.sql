CREATE TABLE [dbo].[Publishers] (
    [PublisherID] INT IDENTITY(1,1) PRIMARY KEY,
    [Name] VARCHAR(100) NOT NULL,
    [Location] VARCHAR(100)
);