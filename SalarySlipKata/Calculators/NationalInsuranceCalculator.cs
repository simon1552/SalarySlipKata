namespace SalarySlipKata.Calculators
{
    public class NationalInsuranceCalculator : INationalInsuranceCalculator
    {
        public decimal Calculate(decimal annualSalary)
        {
            decimal threshold = 8060;
            if (annualSalary <= threshold)
            {
                return 0;
            }
            decimal taxableAmount = annualSalary - threshold;
            var nationalInsuranceContribution = (taxableAmount * 0.12M) /12;
            
            return nationalInsuranceContribution;
        }
    }

}