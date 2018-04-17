using System.Collections.Generic;

namespace EmployeePayrollDeductions.Domain.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Pay { get; set; }
        public decimal BenefitCost { get; set; }
        public virtual List<Dependent> Dependents { get; set; } = new List<Dependent>();        
    }
}
