using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Domain.ErrorModel
{
    public class ErrorModel
    {
        public string ErrorType { get; set; }  // "SQL" or "General"
        public string Message { get; set; }
    }
}