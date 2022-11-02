using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace b3.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
