using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;

namespace WEBWORK.WEB3.Infrastructure.Builders.StudentBuilder
{
    public class StudentAddressBuilder: StudentBuilder
    {
        public StudentAddressBuilder(Student st): base(st)
        {
            this.student = student;
        }

        public StudentAddressBuilder At(string streetAddress)
        {
            this.student.StreetAddress = streetAddress;
            return this;
        }

        public StudentAddressBuilder WithPostCode(string postCode)
        {
            this.student.PostCode = postCode;
            return this;
        }

        public StudentAddressBuilder In(string city)
        {
            this.student.City = city;
            return this;
        }
    }
}
