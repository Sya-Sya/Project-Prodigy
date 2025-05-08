using CollegeApp.Domain.BookModels.AuthorModels;
using CollegeApp.Domain.BookModels.PublisherModels;
using CollegeApp.Domain.Enums;

namespace CollegeApp.Domain.BookModels;

public class BookCommonModel : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public double Rating { get; set; }
    public int StockCount { get; set; }
    public Language Language { get; set; }
    public Format Format { get; set; }
    public Edition Edition { get; set; }
    
    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    public ICollection<BookPublisher> BookPublishers { get; set; } = new List<BookPublisher>();
}