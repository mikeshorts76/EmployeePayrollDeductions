using EmployeePayrollDeductions.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePayrollDeductions.Domain.Interfaces
{
    public interface IDependentService
    {
        Task<List<Dependent>> GetAll();
        Task<Dependent> Get(int id);
        Task<int> Create(Dependent dependent);
        Task Update(Dependent dependent);
        Task Delete(int id);
    }
}
