namespace Courses.Application;

public class CoursesUnitOfWork : UnitOfWork<Course, CourseDTO>, ICoursesUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly ICoursesRepository _coursesRepository;
    public CoursesUnitOfWork(ApplicationDbContext context, ICoursesRepository coursesRepository, IMapper mapper) : base(context, coursesRepository, mapper)
    {
        _context = context;
        _coursesRepository = coursesRepository;
    }


}

