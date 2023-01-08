using System.ComponentModel.DataAnnotations;

namespace Entities;

public class GradeInCourse
{
    [Key]
    public int GradeInCourseId { get; set; }
    [Required]
    [MaxLength(4)]
    public string CourseCode { get; set; }
    [Required]
    public int Grade { get; set; }
    public Student Student { get; set; }
}