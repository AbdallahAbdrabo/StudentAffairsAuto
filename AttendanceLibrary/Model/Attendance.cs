using Courses.Application.Model;


namespace Attendances.Application.Model;

public class Attendance
{
    public int AttendanceId { get; set; }

    public int StudentId { get; set; }
    

    public int CourseId { get; set; }
    public Course? Course { get; set; }

    public DateTime AttendanceDate { get; set; }

    public string? Status { get; set; } // Present, Absent, Late, etc.
}

