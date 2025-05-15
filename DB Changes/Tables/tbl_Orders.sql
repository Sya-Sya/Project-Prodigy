CREATE TABLE [dbo].[Orders] (
    [OrderID] INT IDENTITY(1,1) PRIMARY KEY,
    [MemberID] INT,
    [BookID] INT,
    [Quantity] INT,
    [PriceAtPurchase] DECIMAL(10, 2),
    [ClaimCode] VARCHAR(20) NOT NULL UNIQUE,
    [OrderDate] TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    [Status] VARCHAR(20) DEFAULT 'Pending',
    [TotalAmount] DECIMAL(10, 2),
    FOREIGN KEY (MemberID) REFERENCES Members(MemberID),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);