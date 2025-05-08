namespace CollegeApp.Domain.BookModels.PublisherModels;
public class BookPublisher
{
    public string BookId { get; set; }
    public BookCommonModel Book { get; set; }

    public string PubliserId { get; set; }
    public PublisherCommonModel Publisher { get; set; }
}