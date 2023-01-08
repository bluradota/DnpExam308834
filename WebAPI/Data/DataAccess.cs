using Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebAPI
{
    public class DataAccess : IDataAccess
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<GradeInCourse> GradesInCourse { get; set; }

        protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Students.db");
        }

        private readonly StudentContext _context;

        public DataAccess(StudentContext context)
        {
            _context = context;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task<Student> AddStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return student;
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public async Task<StatisticsOverviewDto> GetStatisticsOverview()
        {
            var statisticsOverviewDto = new StatisticsOverviewDto();
            var students = await _context.Students.ToListAsync();
            var grades = await _context.Grades.ToListAsync();

            statisticsOverviewDto.NumberOfStudents = students.Count;
            statisticsOverviewDto.NumberOfGrades = grades.Count;
            statisticsOverviewDto.AverageGrade = grades.Average(g => g.Grade);
            statisticsOverviewDto.AverageGradePerStudent = grades.Count / students.Count;

            return statisticsOverviewDto;
        }
    }
}