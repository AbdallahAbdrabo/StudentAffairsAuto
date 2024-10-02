namespace Courses.Application;
public class CoursesRepository : Repository<Course>, ICoursesRepository
{
    public CoursesRepository(ApplicationDbContext context) : base(context) { }
}