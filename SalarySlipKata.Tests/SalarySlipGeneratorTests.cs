using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using SalarySlipKata.Calculators;
using SalarySlipKata.Models;

namespace SalarySlipKata.Tests
{
    public class SalarySlipTests
    {
        public Fixture fixture = new Fixture();
        public AutoMocker autoMocker = new AutoMocker();

        [Fact]
        public void GivenIHaveAEmployee_WhenIGenerateFor_ThenCalculateMonthlySalary()
        {
            //Arrange
            var employee = fixture.Create<Employee>();
            var salarySlipGenerator = autoMocker.CreateInstance<SalarySlipGenerator>();

            var nationalInsuranceContributions = fixture.Create<decimal>();

            autoMocker.GetMock<INationalInsuranceCalculator>().Setup(calc => calc.Calculate(employee.annualGrossSalary))
            .Returns(nationalInsuranceContributions);


            //Act
            var result = salarySlipGenerator.GenerateFor(employee);

            //Assert
            decimal expectedMonthlyGrossSalary = employee.annualGrossSalary / 12;
            result.monthlyGrossSalary.Should().Be(Decimal.Round(expectedMonthlyGrossSalary, 2));
            result.EmployeeId.Should().Be(employee.id);
            result.Name.Should().Be(employee.name);
            result.nationalInsuranceContributions.Should().Be(nationalInsuranceContributions);
        }
    }
}