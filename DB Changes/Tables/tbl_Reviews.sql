CREATE TABLE [dbo].[Reviews] (
    [ReviewID] INT IDENTITY(1,1) PRIMARY KEY,
    [BookID] INT,
    [Rating] INT CHECK (Rating BETWEEN 1 AND 5),
    [ReviewText] TEXT,
    [ReviewDate] DATE,
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);