using CollegeApp.Application.Interface;
using CollegeApp.Domain.StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Infrastructure.Services
{
    public class StudentService : IStudentServices
    {
        public IEnumerable<StudentCommonModel> GetAllStudents()
        {
            return new List<StudentCommonModel>
            {
                new StudentCommonModel { id = "1", name = "Bigya GOD" },
                new StudentCommonModel { id = "2", name = "SHINIGAMI" }
            };
        }
    }
}
