namespace Courses.Application;
[Route("api/[controller]")]
[ApiController]
public class CoursesController : BaseController<Course, CourseDTO>
{
    public CoursesController(ICoursesUnitOfWork coursesUnitOfWork) : base(coursesUnitOfWork)
    {

    }
}
