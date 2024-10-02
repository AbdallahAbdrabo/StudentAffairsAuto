namespace faculties.Application;
[Route("api/[controller]")]
[ApiController]
public class FacultiesController : BaseController<Faculty, FacultyDTO>
{
    public FacultiesController(IFacultiesUnitOfWork facultiesUnitOfWork) : base(facultiesUnitOfWork)
    {

    }
}
