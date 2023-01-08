    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    namespace WebApi.Data
    {
        public interface IDataAccess
        {
            Task<Student> CreateStudentAsync(Student student);
            Task<List<Student>> GetAllStudents();
            Task<Student> GetStudentById(int id);
            Task<Student> AddStudent(Student student);
            Task<Student> UpdateStudent(Student student);
            Task<Student> DeleteStudent(int id);
            Task<StatisticsOverviewDto> GetStatisticsOverview();
        }
    }