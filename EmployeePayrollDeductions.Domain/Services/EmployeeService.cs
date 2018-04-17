using EmployeePayrollDeductions.Domain.Interfaces;
using EmployeePayrollDeductions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePayrollDeductions.Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Create(Employee employee)
        {
            await _employeeRepository.Create(employee);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Get(int id)
        {
            var employee = await _employeeRepository.Get(id);

            return employee;
        }

        public async Task<List<Employee>> GetAll()
        {
            var employees = await _employeeRepository.GetAll();

            return employees;
        }

        public Task Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
