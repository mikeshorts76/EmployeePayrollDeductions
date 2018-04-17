namespace EmployeePayrollDeductions.Domain.Models
{
    public partial class Dependent
    {
        public int DependentId { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BenefitCost { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
