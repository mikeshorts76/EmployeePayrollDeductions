namespace EmployeePayrollDeductions.Domain.Models
{
    public class CalculatedBenefitCost
    {
        public decimal TotalDeductions { get; set; }
        public decimal AnnualSalary { get; set; }
        public decimal SalaryAfterDeductions { get; set; }
    }
}
