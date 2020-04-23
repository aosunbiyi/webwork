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
    public class StudentFilter
    {
       public enum Gender { Male,Female};
        public IEnumerable<Student> FilterByGender
            (IEnumerable<Student> students,Gender gender)
        {
            foreach (var st in students)
            {
                if (st.Gender == gender.ToString())
                {
                    yield return st;
                }
            }
        }
    }
}
