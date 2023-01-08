using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Student
{
    [Key]
    public int StudentId { get; set; }
    [Required]
    [MaxLength(25)]
    public string Name { get; set; }
    [Required]
    public string Programme { get; set; }
    public List<GradeInCourse> Grades { get; set; }
}