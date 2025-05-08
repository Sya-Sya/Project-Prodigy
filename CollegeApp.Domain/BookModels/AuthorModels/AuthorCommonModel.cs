namespace CollegeApp.Domain.BookModels.AuthorModels;

public class AuthorCommonModel : BaseModel
{
    public string Name { get; set; }

    public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}