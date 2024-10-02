namespace CustomerServiceApp.Server.MapperProfiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Student,StudentDTO>().ReverseMap();
        CreateMap<Faculty,FacultyDTO>().ReverseMap();
        CreateMap<Course, CourseDTO>().ReverseMap();
      
    }
}
