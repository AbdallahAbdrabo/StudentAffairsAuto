using Courses.Application;


namespace Departments.Application.Model;

public class Department
{
    public int DepartmentID { get; set; }
    public string? DepartmentName { get; set; }

   
    public ICollection<Course>? Courses { get; set; }

}
