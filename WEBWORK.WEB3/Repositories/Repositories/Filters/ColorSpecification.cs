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
    public class ColorSpecification : ISpecification<Student>
    {
        private string color;
        public ColorSpecification(string _color)
        {
            this.color = _color;
        }
        public bool IsSatisfied(Student item)
        {
            return item.Color == color;
        }
    }
}
