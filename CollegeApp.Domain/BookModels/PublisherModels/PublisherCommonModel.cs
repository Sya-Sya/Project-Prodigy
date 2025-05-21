namespace CollegeApp.Domain.BookModels.PublisherModels;

public class PublisherCommonModel
{
    public string Name { get; set; }

    public ICollection<BookCommonModel> Books { get; set; } = new List<BookCommonModel>();
}