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
    public class LovelyStudentFilter : IFilter<Student>
    {
        public IEnumerable<Student> Filter(IEnumerable<Student> items, ISpecification<Student> spec)
        {
            foreach (var item in items)
            {
                if (spec.IsSatisfied(item))
                    yield return item;
            }
        }
    }
}
