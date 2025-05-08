using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Domain.BookModels
{
    public class BookCommonModel : BaseModel
    {
        public string authorName { get; set; }
        public string bookName { get; set; }
    }
}
