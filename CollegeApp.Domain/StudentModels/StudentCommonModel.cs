namespace CollegeApp.Domain.StudentModels;

public class StudentCommonModel /*: BaseModel//Student related models*/
{
    public string StudentId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string EnrollmentDate { get; set; }
}