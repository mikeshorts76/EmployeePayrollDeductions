using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EmployeePayrollDeductions.Web.Models
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public decimal Pay
        {
            get { return 2000M * 26M; }
        }
        public decimal BenefitCost
        {
            get
            {
                if (IsDiscount)
                    return 1000M - ((10M / 100M) * 1000M);
                else
                    return 1000M;
            }
        }
        public decimal TotalBenefitCost
        {
            get
            {
                return Dependents.Sum(x => x.BenefitCost) + BenefitCost;
            }
        }
        
        public List<DependentViewModel> Dependents { get; set; }
        public bool Visible { get; set; }
        public bool IsDiscount
        {
            get
            {
                if (FirstName.StartsWith("A", true, CultureInfo.InvariantCulture))
                    return true;
                else
                    return false;
            }
        }

        public EmployeeViewModel()
        {
            Dependents = new List<DependentViewModel>();
        }
    }

}
