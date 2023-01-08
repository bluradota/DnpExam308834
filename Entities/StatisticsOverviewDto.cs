

namespace Entities
{
    public class StatisticsOverviewDto
    {
        public string CourseCode { get; set; }
        public int NumberOfStudents { get; set; }
        public int NumberOfGrades { get; set; }
        public double AverageGrade { get; set; }
        public double AverageGradePerStudent { get; set; }
    }
}