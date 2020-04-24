using System;
using System.Collections.Generic;
using System.Text;

namespace WEBWORK.DATA.Models
{
    public class AcademicSet
    {
        public AcademicSet()
        {
            Students = new HashSet<Student>();
        }
        public long AcademicSetId { get; set; }
        public string Name { get; set; }
        public DateTime Entry { get; set; }
        public DateTime Exit { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
