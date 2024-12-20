using AutoMapper;
using Demo.BLL.Models.DTO;
using Demo.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Mappings
{
    public class AutoMapperProfiles : Profile
	{
        public AutoMapperProfiles()
        {
			CreateMap<Company, GetCompanyDto>().ReverseMap();
			CreateMap<Company, AddCompanyDto>().ReverseMap();
			CreateMap<Company, EditCompanyDto>().ReverseMap();
			CreateMap<Employee, GetEmployeeDto>().ReverseMap();
			CreateMap<Employee, AddEmployeeDto>().ReverseMap();
			CreateMap<Employee, EditEmployeeDto>().ReverseMap();
		}
    }
}
