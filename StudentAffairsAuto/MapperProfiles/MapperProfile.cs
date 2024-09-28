namespace CustomerServiceApp.Server.MapperProfiles;

using AutoMapper;
using Students.Application.Model;
using Students.Client.Dto;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Student,StudentDTO>().ReverseMap();
        //CreateMap<City, CityViewModel>().ReverseMap();
        //CreateMap<Service, ServiceViewModel>().ReverseMap();

        //CreateMap<Customer, CustomerViewModel>().ForMember(e => e.CityName, opt => opt.MapFrom(src => src.City.Name));
        //CreateMap<CustomerViewModel, Customer>();

        //CreateMap<CustomerRequest, CustomerRequestViewModel>()
        //    .ForMember(e => e.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
        //    .ForMember(e => e.ServiceName, opt => opt.MapFrom(src => src.Service.Name));
        //CreateMap<CustomerRequestViewModel, CustomerRequest>();
    }
}
