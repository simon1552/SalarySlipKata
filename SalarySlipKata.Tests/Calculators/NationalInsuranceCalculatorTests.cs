using AutoFixture;
using FluentAssertions;
using Moq.AutoMock;
using SalarySlipKata.Calculators;
using SalarySlipKata.Models;

namespace SalarySlipKata.Tests.Calculators
{
    public class NationalInsuranceCalculatorTests
    {
        public Fixture fixture = new Fixture();
        public AutoMocker autoMocker = new AutoMocker();

        [Fact]
        public void GivenAnEmployeeHasLessThan8060AnnualSalary_WhenICalculate_IReturn0()
        {
            //Arrange
            var salary = 5000;
            var subject = autoMocker.CreateInstance<NationalInsuranceCalculator>();
            //Act
            var result = subject.Calculate(salary);
            //Assert
            result.Should().Be(0);
        }

        
        [Fact]
        public void GivenAnEmployeeHasOverThan8060AnnualSalary_WhenICalculate_IReturn0()
        {
            //Arrange
            var salary = 8060 + fixture.Create<decimal>();
            var subject = autoMocker.CreateInstance<NationalInsuranceCalculator>();
            //Act
            var result = subject.Calculate(salary);
            //Assert

            var taxableAmount = salary - 8060;
            var expectedNationalInsuranceContribution = (taxableAmount * 0.12M) /12;


            result.Should().Be(expectedNationalInsuranceContribution);
        }
    }
}