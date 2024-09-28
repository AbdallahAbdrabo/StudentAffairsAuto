namespace Students.Application.Repository1;

public class StudentsRepository : Repository<Student>, IStudentsRepository
{
    public StudentsRepository(ApplicationDbContext context) : base(context) { }


}