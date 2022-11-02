using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace b3.Models
{
    public class Class
    {
        public int ClassID { get; set; }
        public string Title { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
