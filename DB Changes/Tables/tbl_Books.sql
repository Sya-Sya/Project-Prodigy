CREATE TABLE [dbo].[Books] (
    [BookID] INT IDENTITY(1,1) PRIMARY KEY,
    [Title] VARCHAR(150) NOT NULL,
    [ISBN] VARCHAR(20) UNIQUE,
    [Description] TEXT,
    [PublicationDate] DATE,
    [Language] VARCHAR(50),
    [Price] DECIMAL(10, 2),
    [Stock] INT,
    [Popularity] INT DEFAULT 0,
    [PublisherID] INT,
    [FormatID] INT,
    FOREIGN KEY (PublisherID) REFERENCES Publishers(PublisherID),
    FOREIGN KEY (FormatID) REFERENCES Formats(FormatID)
);

-- Indexes for Efficient Searching and Filtering
CREATE INDEX idx_book_title ON Books(Title);
CREATE INDEX idx_book_price ON Books(Price);
CREATE INDEX idx_book_pubdate ON Books(PublicationDate);
CREATE INDEX idx_book_popularity ON Books(Popularity);