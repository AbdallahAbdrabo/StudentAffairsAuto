namespace faculties.Application;

public class FacultiesUnitOfWork : UnitOfWork<Faculty, FacultyDTO>, IFacultiesUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IFaculiesRepository _faculiesRepository;
    public FacultiesUnitOfWork(ApplicationDbContext context, IFaculiesRepository faculiesRepository, IMapper mapper) : base(context, faculiesRepository, mapper)
    {
        _context = context;
        _faculiesRepository = faculiesRepository;
    }


}

