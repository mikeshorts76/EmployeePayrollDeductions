using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
            try
            {
                var employees = await _employeeService.GetAll();

                var mappedEmployees = Mapper.Map<List<Employee>, List<EmployeeViewModel>>(employees);

                return Ok(mappedEmployees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }           
        }

        [HttpGet("{id}")]        
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var employee = await _employeeService.Get(id);

                var mappedEmployee = Mapper.Map<Employee, EmployeeViewModel>(employee);

                return Ok(mappedEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }            
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]EmployeeViewModel employee)
        {
            var employeeMapped = Mapper.Map<EmployeeViewModel, Employee>(employee);

            try
            {
                var id = await _employeeService.Create(employeeMapped);

                employee.EmployeeId = id;

                return Created(new Uri($"{Request.Path}/{id}", UriKind.Relative), employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            
        }
    }
}
