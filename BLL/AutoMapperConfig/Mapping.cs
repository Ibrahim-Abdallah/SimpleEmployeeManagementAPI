using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AutoMapperConfig
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<IdentityUser, RegisterModel>().ReverseMap();
            CreateMap<BaseEntity, BaseEntityDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name)).ReverseMap();
        }
    }
}
