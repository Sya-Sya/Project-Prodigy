using CollegeApp.Domain.BookModels.PublisherModels;

namespace CollegeApp.Domain.BookModels;

public class BookCommonModel
{
    public int BookID { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public string Description { get; set; }
    public DateTime? PublicationDate { get; set; }
    public string Language { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public int Popularity { get; set; } = 0;
    public int PublisherID { get; set; }
    public int FormatID { get; set; }

    // Optional navigation properties (if using EF or manually joining)
    public PublisherCommonModel Publisher { get; set; }
    public FormatCommonModel Format { get; set; }
}