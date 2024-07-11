using FluentAssertions;
using SalarySlipKata.Calculators;
using SalarySlipKata.Models;

namespace SalarySlipKata.Tests
{
    public class IterationTests
    {
        [Fact]
        public void Iteration1()
        {
            //Arrange
            var employee = new Employee(12345, "John J Doe", 5000);
            var salarySlipGenerator = new SalarySlipGenerator( new NationalInsuranceCalculator());
            //Act
            var result = salarySlipGenerator.GenerateFor(employee);
            //Assert

            decimal expectedMonthlyGrossSalary = 416.67M;
            result.monthlyGrossSalary.Should().Be(expectedMonthlyGrossSalary);
        }
        [Fact]
        public void Iteration2()
        {
            //Arrange
            var employee = new Employee(12345, "John J Doe", 9060);
            var salarySlipGenerator = new SalarySlipGenerator(new NationalInsuranceCalculator());
            //Act
            var result = salarySlipGenerator.GenerateFor(employee);
            //Assert

            result.monthlyGrossSalary.Should().Be(755M);
            result.nationalInsuranceContributions.Should().Be(10);
        }
    }
}