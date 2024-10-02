
using Exams.Application.Model;


namespace Courses.Application;

public class Course
{
    public int? CourseID { get; set; }
    public string? CourseName { get; set; }
    public string? Description { get; set; }
    public string? CourseCode { get; set; }

    public ICollection<Exam>? Exams { get; set; }

    public int DepartmentId { get; set; }

}