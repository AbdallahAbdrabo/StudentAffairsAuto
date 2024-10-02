namespace faculties.Application;
public class FaculiesRepository : Repository<Faculty>, IFaculiesRepository
{
    public FaculiesRepository(ApplicationDbContext context) : base(context) { }
}