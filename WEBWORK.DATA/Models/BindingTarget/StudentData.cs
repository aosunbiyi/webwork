using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WEBWORK.DATA.Models.BindingTarget
{
    public class StudentData
    {
        [Required]
        public string FirstName { get=> Student.FirstName; set=> Student.FirstName = value; }
        [Required]
        public string LastName { get => Student.LastName; set => Student.LastName=value; }
        [Required]
        public string Email { get => Student.Email; set => Student.Email = value; }
        [Required]
        public string Phone { get => Student.Phone; set=> Student.Phone= value; }
     

        public Student Student { get; set; } = new Student();
    }
}
