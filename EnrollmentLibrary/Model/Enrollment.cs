using Courses.Application.Model;


namespace Enrollments.Application.Model;

public class Enrollment
{
    public int EnrollmentId { get; set; }
    public DateOnly EnrollmentDate { get; set; }
    public int Grade { get; set; }

    public int CourseId { get; set; }
    public Course? Course { get; set; }

    public int StudentId { get; set; }
    

}
