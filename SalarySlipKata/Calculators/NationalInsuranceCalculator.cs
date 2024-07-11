namespace SalarySlipKata.Calculators
{
    public class NationalInsuranceCalculator : INationalInsuranceCalculator
    {
        public decimal Calculate(decimal annualSalary)
        {
            if (annualSalary < 8060)
            {
                return 0;
            }
            var nationalInsuranceContribution = (annualSalary * 0.12M) /12;
            return nationalInsuranceContribution;
        }
    }

}