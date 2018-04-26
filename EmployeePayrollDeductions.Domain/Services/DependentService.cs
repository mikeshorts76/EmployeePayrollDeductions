using EmployeePayrollDeductions.Domain.Interfaces;
using EmployeePayrollDeductions.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeePayrollDeductions.Domain.Services
{
    public class DependentService : IDependentService
    {
        private readonly IRepository<Dependent> _dependentRepository;

        public DependentService(IRepository<Dependent> dependentRepository)
        {
            _dependentRepository = dependentRepository;
        }

        public async Task<int> Create(Dependent dependent)
        {
            var id = await _dependentRepository.Create(dependent);

            return id;
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

        public Task Update(Dependent dependent)
        {
            throw new NotImplementedException();
        }
    }
}
