using AutoMapper;
using Entities.DTOs;
using Entities.Models;


namespace EmployeeManagementManila
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
