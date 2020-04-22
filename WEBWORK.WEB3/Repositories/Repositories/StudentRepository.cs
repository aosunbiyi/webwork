using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;
using WEBWORK.WEB3.Repositories.IRepositories;
using WEBWORK.DATA.Data;

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
            return this.context.Students.Where(a => a.Email.Equals(email)).ToList();
        }
    }
}
