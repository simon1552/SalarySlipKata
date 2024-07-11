using SalarySlipKata.Calculators;
using SalarySlipKata.Models;

namespace SalarySlipKata
{
    public class SalarySlipGenerator
    {
        private readonly INationalInsuranceCalculator _nationalInsuranceCalculator;

        public SalarySlipGenerator(INationalInsuranceCalculator nationalInsuranceCalculator)
        {
            _nationalInsuranceCalculator = nationalInsuranceCalculator;
        }
        public SalarySlip GenerateFor(Employee employee)
        {
            var nationalInsuranceContribution = _nationalInsuranceCalculator.Calculate(employee.annualGrossSalary);            

           var salarySlip = new SalarySlip(employee.id, employee.name, Decimal.Round(employee.annualGrossSalary / 12 , 2), nationalInsuranceContribution);
           return salarySlip;
        }
    }
}
