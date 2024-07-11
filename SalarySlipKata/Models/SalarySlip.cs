namespace  SalarySlipKata.Models
{
    public record SalarySlip
    (
         int EmployeeId,
         string Name,
         decimal monthlyGrossSalary,
         decimal nationalInsuranceContributions
    );

}