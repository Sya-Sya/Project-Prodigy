CREATE TABLE [dbo].[Whitelist] (
    [MemberID] INT,
    [BookID] INT,
    PRIMARY KEY (MemberID, BookID),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);