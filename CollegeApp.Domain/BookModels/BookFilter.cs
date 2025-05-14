namespace CollegeApp.Domain.BookModels;
public class BookFilter : BaseFilter
{
}
//My office table
public class agentContact
{
    public int rowID { get; set; }
    public string agentID { get; set; }
    public string branchID { get; set; }
    public string mobile { get; set; }
    public string isMobileVerified { get; set; }
    public string email { get; set; }
    public string isEmailVerified { get; set; }
    public string createdBy { get; set; }
    public string createdDate { get; set; }
}