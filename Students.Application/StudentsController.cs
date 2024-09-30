namespace Students.Application;
[Route("api/[controller]")]
[ApiController]
public class StudentsController : BaseController<Student, StudentDTO>
{
    public StudentsController(IStudentsUnitOfWork studentsUnitOfWork) : base(studentsUnitOfWork)
    {

    }
}
