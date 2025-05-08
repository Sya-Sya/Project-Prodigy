namespace CollegeApp.Domain.BookModels.AuthorModels;

public class BookAuthor
{
    public string BookId { get; set; }
    public BookCommonModel Book { get; set; }

    public string AuthorId { get; set; }
    public AuthorCommonModel Author { get; set; }
}