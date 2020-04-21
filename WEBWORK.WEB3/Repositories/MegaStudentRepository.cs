using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBWORK.DATA.Data;
using WEBWORK.DATA.Models;

namespace WEBWORK.WEB3.Repositories
{
    public class MegaStudentRepository : IRepository<Student>
    {
        private ApplicationContext context { get; set; }

        public MegaStudentRepository(ApplicationContext _context)
        {
            this.context = _context;
        }
        public Student Create(Student entity)
        {
            this.context.Add(entity);
            return entity;
        }

        public void Delete(int id)
        {
            var st = this.context.Students.Find(id);
            this.context.Students.Remove(st);
            context.SaveChanges();
        }

        public Student Get(int id)
        {
            var st = this.context.Students.Find(id);
            return st;
        }

        public IEnumerable<Student> GetAll()
        {
            return this.context.Students.ToList();
        }

        public void Update(Student entity)
        {
            var st = this.context.Students.Find(entity.StudentId);
            st.FirstName = entity.FirstName;
            context.SaveChanges();
        }
    }
}
