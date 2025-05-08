using CollegeApp.Domain.StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Application.Interface
{
    public interface IStudentServices
    {
        IEnumerable<StudentCommonModel> GetAllStudents();
    }
}
