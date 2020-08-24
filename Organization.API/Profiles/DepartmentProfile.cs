using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Organization.API.Dto;
using Organization.API.Model;

namespace Organization.API.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();

            CreateMap<DepartmentForUpdateDto, Department>();
        }
    }
}
