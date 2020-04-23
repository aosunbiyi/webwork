using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WEBWORK.DATA.Models;

namespace WEBWORK.DATA.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public DbSet<StudentSubjectMapping> StudentSubjectMapping { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentSubjectMapping>().HasKey(sc=> new { sc.StudentId, sc.SubjectId});

            builder.Entity<StudentSubjectMapping>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentSubjects)
                .HasForeignKey(sc=> sc.StudentId);

            builder.Entity<StudentSubjectMapping>()
               .HasOne<Subject>(sc => sc.Subject)
               .WithMany(s => s.StudentSubjects)
               .HasForeignKey(sc => sc.SubjectId);


        }

    }
}
