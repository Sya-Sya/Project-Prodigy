using CollegeApp.Application.Interface;
using CollegeApp.Domain.StudentModels;

namespace CollegeApp.Infrastructure.Services
{
    public class StudentService : IStudentServices
    {
        public IEnumerable<StudentCommonModel> GetAllStudents()
        {
            return new List<StudentCommonModel>
            {
                new StudentCommonModel { Id = "1", Name = "Bigya GOD" },
                new StudentCommonModel { Id = "2", Name = "SHINIGAMI" }
            };
        }
    }
}