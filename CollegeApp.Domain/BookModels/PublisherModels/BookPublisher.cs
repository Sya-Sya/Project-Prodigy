namespace CollegeApp.Domain.BookModels.PublisherModels;
public class BookPublisher
{
    public string BookId { get; set; }
    public BookCommonModel Book { get; set; }

    public string PublisherId { get; set; }
    public PublisherCommonModel Publisher { get; set; }
}