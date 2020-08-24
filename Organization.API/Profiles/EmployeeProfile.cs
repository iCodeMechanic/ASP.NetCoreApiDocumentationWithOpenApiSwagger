using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Organization.API.Dto;
using Organization.API.Model;

namespace Organization.API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.DepartmentName
                    , opt => opt.MapFrom(src => src.Department.Name));
            CreateMap<EmployeeForCreationDto, Employee>();
        }
    }
}
