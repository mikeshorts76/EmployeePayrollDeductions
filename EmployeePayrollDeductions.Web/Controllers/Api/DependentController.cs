using AutoMapper;
using EmployeePayrollDeductions.Domain.Interfaces;
using EmployeePayrollDeductions.Domain.Models;
using EmployeePayrollDeductions.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeePayrollDeductions.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class DependentController : Controller
    {
        private IDependentService _dependentService;

        public DependentController(IDependentService dependentService)
        {
            _dependentService = dependentService;
        }

        [HttpPost]        
        public async Task<IActionResult> Create([FromBody]DependentViewModel dependent)
        {            
            try
            {
                var dependentMapped = Mapper.Map<DependentViewModel, Dependent>(dependent);

                await _dependentService.Create(dependentMapped);

                return Created("", dependent);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }                        
        }
    }
}
