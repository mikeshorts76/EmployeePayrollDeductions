using AutoMapper;
using EmployeePayrollDeductions.Domain.Models;
using EmployeePayrollDeductions.Web.Models;

namespace EmployeePayrollDeductions.Web
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Dependent, DependentViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();            
        }
    }
}
