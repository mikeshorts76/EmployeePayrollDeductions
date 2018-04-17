using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePayrollDeductions.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task Create(T item);
        Task Update(T item);
        Task Delete(int id);
    }
}
