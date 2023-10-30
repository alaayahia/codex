
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDocument, EmpDocDto>()
             .ForMember(dest => dest.EmpName, opt => opt.MapFrom(src =>
            src.Employee.EmpName));
            CreateMap<EmployeeCompensation, EmpCompDto>()
            .ForMember(dest => dest.CompName, opt => opt.MapFrom(src =>
            src.Compensation.CompName))
            .ForMember(dest => dest.EmpName, opt => opt.MapFrom(src =>
            src.Employee.EmpName));
            CreateMap<Compensation, CompensationDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<CompensationDto, Compensation>();
            CreateMap<EmpCompDto, EmployeeCompensation>();
            CreateMap<EmpDocDto, EmployeeDocument>();
        }
    }
}