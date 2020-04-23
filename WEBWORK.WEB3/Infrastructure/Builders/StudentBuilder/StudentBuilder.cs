using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;

namespace WEBWORK.WEB3.Infrastructure.Builders.StudentBuilder
{
    public class StudentBuilder
    {
        protected Student student;
        public StudentBuilder() => student = new Student();
        protected StudentBuilder(Student student) => this.student = student;

        public StudentAddressBuilder Lives => new StudentAddressBuilder(student);
        public StudentRankBuilder Ranks => new StudentRankBuilder(student);

        public static implicit operator Student (StudentBuilder builder)
        {
            return builder.student;
        }
    }
}
