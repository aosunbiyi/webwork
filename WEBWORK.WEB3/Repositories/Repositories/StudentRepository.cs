using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;
using WEBWORK.WEB3.Repositories.IRepositories;
using WEBWORK.DATA.Data;
using WEBWORK.WEB3.Repositories.Repositories.Filters;

namespace WEBWORK.WEB3.Repositories.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationContext context;

        public StudentRepository(ApplicationContext _context): base(_context)
        {
            context = _context;
        }


        public IEnumerable<Student> GetByEmail(string email)
        {

            var list = this.context.Students.Where(a => a.Email.Equals(email)).ToList();
            var list2 = new List<Student>();
            LovelyStudentFilter filter = new LovelyStudentFilter();

            foreach (var item in filter.Filter(list, new SpecContainer<Student>(
                new ColorSpecification("red"),
                new GenderSpecification("male")
                )))
            {
                list2.Add(item);
            }

            return list2;
        }
    }
}
