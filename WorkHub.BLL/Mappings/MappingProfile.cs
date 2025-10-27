using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkHub.BLL.DTOs;
using WorkHub.DAL.Models;

namespace WorkHub.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee,EmployeeDTO>().ReverseMap().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
