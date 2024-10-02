namespace Students.Application;

public class StudentsRepository : Repository<Student>, IStudentsRepository
{
    public StudentsRepository(ApplicationDbContext context) : base(context) { }


}