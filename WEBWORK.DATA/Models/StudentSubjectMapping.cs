using System;
using System.Collections.Generic;
using System.Text;

namespace WEBWORK.DATA.Models
{
    public  class StudentSubjectMapping
    {
        public long StudentId { get; set; }
        public Student Student { get; set; }
        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
