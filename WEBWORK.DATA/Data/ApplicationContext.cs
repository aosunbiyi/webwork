using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WEBWORK.DATA.Models;
using System.Linq;

namespace WEBWORK.DATA.Data
{
    public class ApplicationContext: DbContext
    {

        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<AcademicSet> AcademicSets { get; set; }

        public DbSet<StudentSubjectMapping> StudentSubjectMapping { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=WebWorkDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

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



            builder.Entity<Student>()
                .HasOne(a => a.AcademicSet)
                     .WithMany(p => p.Students)
                     .HasForeignKey(d => d.AcademicSetId)
                     .OnDelete(DeleteBehavior.Cascade)
                     .HasConstraintName("academic_set_student_key");

      


        }

    }
}
