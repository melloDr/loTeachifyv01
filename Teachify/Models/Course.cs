using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teachify.Models
{
    public class Course
    {
        public string Name {get;set;}
    }
    public class ResultCoursesModel
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public List<Course> Data { get; set; }
        public object ResponseFailed { get; set; }
        public string Message { get; set; }
    }
}