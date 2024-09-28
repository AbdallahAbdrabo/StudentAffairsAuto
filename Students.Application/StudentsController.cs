using Microsoft.AspNetCore.Mvc;
using Shared.Application.Controlllers;
using Students.Application.UnitOfWork1;

namespace Students.Application;
[Route("api/[controller]")]
[ApiController]
public class StudentsController : BaseController<Student>
{
    public StudentsController(IStudentsUnitOfWork studentsUnitOfWork) : base(studentsUnitOfWork)
    {

    }
}
