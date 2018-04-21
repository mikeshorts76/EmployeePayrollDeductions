using EmployeePayrollDeductions.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePayrollDeductions.Domain.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> Get(int id);
        Task<int> Create(Employee employee);
        Task Update(Employee employee);
        Task Delete(int id);
    }
}
