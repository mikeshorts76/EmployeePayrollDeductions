using EmployeePayrollDeductions.Domain.Interfaces;
using EmployeePayrollDeductions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePayrollDeductions.Domain.Repositories
{
    public class DependentRepository : IRepository<Dependent>
    {
        private readonly DatabaseContext _context;

        public DependentRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Create(Dependent item)
        {
            await _context.Dependents.AddAsync(item);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Dependent> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Dependent>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(Dependent item)
        {
            throw new NotImplementedException();
        }
    }
}
