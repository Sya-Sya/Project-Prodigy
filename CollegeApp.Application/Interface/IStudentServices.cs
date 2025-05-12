using CollegeApp.Domain.StudentModels;

namespace CollegeApp.Application.Interface;

public interface IStudentServices
{
    IEnumerable<StudentCommonModel> GetAllStudents();
}