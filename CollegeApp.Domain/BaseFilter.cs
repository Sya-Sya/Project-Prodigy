namespace CollegeApp.Domain;
public class BaseFilter
{
    public string SearchKeyword { get; set; }
    public int SkipCount { get; set; } = 0;
    public int MaxResultCount { get; set; } = 10;
    public string Sorting { get; set; } = "CreatedDate DESC";
    public DateTime? CreatedDate { get; set; }
    public DateTime? LastLoginAt { get; set; }
}