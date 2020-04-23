using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Data;
using WEBWORK.DATA.Models;
using WEBWORK.WEB3.Repositories.IRepositories;

namespace WEBWORK.WEB3.Repositories.Repositories
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private ApplicationContext context;
        public SubjectRepository(ApplicationContext context):base(context)
        {
            this.context = context;
        }

        public IEnumerable<Student> getStudentsBySubject(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subject> searchSubject(string name)
        {
            throw new NotImplementedException();
        }
    }
}
