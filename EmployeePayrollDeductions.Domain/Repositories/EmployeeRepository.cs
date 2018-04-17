using EmployeePayrollDeductions.Domain.Interfaces;
using EmployeePayrollDeductions.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePayrollDeductions.Domain.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private readonly DatabaseContext _context;

        public EmployeeRepository(DatabaseContext context)
        {

            _context = context;
        }

        public async Task Create(Employee item)
        {
            await _context.Employees.AddAsync(item);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Get(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Dependents)
                .SingleAsync(e => e.EmployeeId == id);                
                                
            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await _context.Employees
                    .Include(e => e.Dependents)
                    .ToListAsync();

            return employees;
        }

        public async Task Update(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
