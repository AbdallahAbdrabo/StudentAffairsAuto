namespace Students.Application;

public class StudentsUnitOfWork : UnitOfWork<Student, StudentDTO>, IStudentsUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IStudentsRepository _studentsRepository;
    public StudentsUnitOfWork(ApplicationDbContext context, IStudentsRepository studentsRepository, IMapper mapper) : base(context, studentsRepository ,mapper)
    {
        _context = context;
        _studentsRepository = studentsRepository;
    }
}