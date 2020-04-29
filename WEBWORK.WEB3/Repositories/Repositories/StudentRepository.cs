using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WEBWORK.DATA.Models;
using WEBWORK.WEB3.Repositories.IRepositories;
using WEBWORK.DATA.Data;
using WEBWORK.WEB3.Repositories.Repositories.Filters;
using Microsoft.EntityFrameworkCore;

namespace WEBWORK.WEB3.Repositories.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private ApplicationContext context;

        public StudentRepository(ApplicationContext _context): base(_context)
        {
            context = _context;
        }

        public IEnumerable<Student> CreateRelationship()
        {
            AcademicSet set = new AcademicSet { Name="2002 Set"};
            context.AcademicSets.Add(set);
            context.SaveChanges();

            Student st1 = new Student {  FirstName="Test", LastName="Test2", AcademicSet=set};
            Student st2 = new Student { FirstName = "Test1", LastName = "Test2", AcademicSet = new AcademicSet { Name="2009 Set"} };
            Subject sb1 = new Subject { Name="Mathematics" };
            Subject sb2 = new Subject { Name="English" };

            StudentSubjectMapping mapping = new StudentSubjectMapping();
            mapping.Student = st1;
            mapping.Subject = sb1;
            context.StudentSubjectMapping.Add(mapping);
            context.SaveChanges();

            var students = context.Students.Include(a => a.StudentSubjects).ToList();
            return students;

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
