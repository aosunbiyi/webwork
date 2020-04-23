using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;

namespace WEBWORK.WEB3.Repositories.IRepositories
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        IEnumerable<Subject> searchSubject(string name);

        IEnumerable<Student> getStudentsBySubject(string name);
    }
}
