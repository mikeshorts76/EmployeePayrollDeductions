using EmployeePayrollDeductions.Domain.Interfaces;
using EmployeePayrollDeductions.Web.Models;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Create(DependentViewModel dependent)
        {
            return Ok();
        }
    }
}
