namespace CollegeApp.Domain.BookModels.AuthorModels;

public class AuthorCommonModel
{
    public string Name { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}