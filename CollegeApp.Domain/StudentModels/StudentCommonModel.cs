using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Domain.StudentModels
{
    public class StudentCommonModel : BaseModel//Student related models
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
