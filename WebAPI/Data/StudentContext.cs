using Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Data
{
    public class StudentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite(
                @"Data Source = C:\Users\cosar\Desktop\Exam DNP\DnpExam308834\WebAPI\StudentsDatabase.db");
        }
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<GradeInCourse> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => s.StudentId);
            modelBuilder.Entity<Student>().Property(s => s.Name).HasMaxLength(25).IsRequired();
            modelBuilder.Entity<Student>().Property(s => s.Programme).IsRequired();

            modelBuilder.Entity<GradeInCourse>().HasKey(g => g.GradeInCourseId);
            modelBuilder.Entity<GradeInCourse>().Property(g => g.CourseCode).HasMaxLength(4).IsRequired();
            modelBuilder.Entity<GradeInCourse>().Property(g => g.Grade).IsRequired();
        }
    }
}