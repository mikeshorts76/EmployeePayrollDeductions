using System.Globalization;

namespace EmployeePayrollDeductions.Web.Models
{
    public class DependentViewModel
    {
        public int DependentId { get; set; }
        public int EmployeeId { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }        
        public decimal BenefitCost
        {
            get
            {
                if (FirstName.StartsWith("A", true, CultureInfo.InvariantCulture))
                    return 500M - ((10M / 100M) * 500M);
                else
                    return 500M;
            }
        }
    }
}
