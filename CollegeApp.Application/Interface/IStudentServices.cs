using CollegeApp.Domain.StudentModels;

namespace CollegeApp.Application.Interface;

public interface IStudentServices
{
    IEnumerable<StudentCommonModel> GetAllStudents();
    StudentCommonModel GetStudentById(int id);
    int AddStudent(StudentCommonModel student);
    int UpdateStudent(StudentCommonModel student);
    int DeleteStudent(int id);
}