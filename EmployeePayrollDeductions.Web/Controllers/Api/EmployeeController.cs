using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EmployeePayrollDeductions.Domain;
using EmployeePayrollDeductions.Domain.Interfaces;
using EmployeePayrollDeductions.Domain.Models;
using EmployeePayrollDeductions.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePayrollDeductions.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;        

        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAll();

            var returnValue = Mapper.Map<List<Employee>, List<EmployeeViewModel>>(employees);

            return Ok(returnValue);
        }

        [HttpGet("{id}")]        
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeService.Get(id);

            var returnValue = Mapper.Map<Employee, EmployeeViewModel>(employee);

            return Ok(returnValue);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeViewModel employee)
        {
            var employeeMapped = Mapper.Map<EmployeeViewModel, Employee>(employee);

            await _employeeService.Create(employeeMapped);

            return Created("", employee);
        }
    }
}
