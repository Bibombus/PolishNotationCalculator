using Xunit;
using Calculator;

namespace Calculator.Tests
{
    public class PolishNotationCalculatorTests
    {
        [Fact]
        public void GIVEN_simple_addition_WHEN_calculate_THEN_return_sum()
        {
            var calculator = new PolishNotationCalculator();
            var result = calculator.Calculate("+ 1 2");
            Assert.Equal(3, result);
        }
    }
}