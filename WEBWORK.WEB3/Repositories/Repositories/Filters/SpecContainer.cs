using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/// <summary>
/// Open-Closed Principle
/// </summary>

namespace WEBWORK.WEB3.Repositories.Repositories.Filters
{
    public class SpecContainer<T> : ISpecification<T>
    {
        private readonly ISpecification<T> first, second;
        public SpecContainer(ISpecification<T> first, ISpecification<T> second)
        {
            this.first = first;
            this.second = second;
        }
        public bool IsSatisfied(T item)
        {
            return first.IsSatisfied(item) && second.IsSatisfied(item);
        }
    }
}
