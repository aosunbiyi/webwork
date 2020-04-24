using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WEBWORK.DATA.Models
{
    public class Student : Entity
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubjectMapping>();
        }
        public long StudentId { get; set; }

        public long AcademicSetId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public string StreetAddress { get; set; }
        public string  PostCode { get; set; }
        public string City { get; set; }

        public string Position { get; set; }
        public string RankName { get; set; }

        public AcademicSet AcademicSet { get; set; }

        public ICollection<StudentSubjectMapping> StudentSubjects { get; set; }

    }
}
