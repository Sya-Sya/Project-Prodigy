using CollegeApp.Domain;
using CollegeApp.Domain.StudentModels;

namespace CollegeApp.Application.Interface;

public interface IStudentServices
{
    BaseResponseModel<StudentCommonModel> AddStudent(StudentCommonModel student);
    BaseResponseModel<IEnumerable<StudentCommonModel>> GetAllStudents();
    BaseResponseModel<StudentCommonModel> GetStudentById(int id);
    BaseResponseModel<StudentCommonModel> DeleteStudent(int id);
    BaseResponseModel<StudentCommonModel> UpdateStudent(StudentCommonModel student);
}