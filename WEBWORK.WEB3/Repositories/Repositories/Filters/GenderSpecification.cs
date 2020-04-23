using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;


/// <summary>
/// Open-Closed Principle
/// </summary>


namespace WEBWORK.WEB3.Repositories.Repositories.Filters
{
    public class GenderSpecification : ISpecification<Student>
    {
        private string gender;
        public GenderSpecification(string _gender)
        {
            this.gender = _gender;
        }
        public bool IsSatisfied(Student item)
        {
            return item.Gender == this.gender;
        }
    }
}
