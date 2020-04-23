using System;
using System.Collections.Generic;
using System.Text;

namespace WEBWORK.DATA.Models
{
    public class Subject: Entity
    {
        public Subject()
        {
            StudentSubjects = new HashSet<StudentSubjectMapping>();
        }
        public long SubjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<StudentSubjectMapping> StudentSubjects { get; set; }
    }
}
