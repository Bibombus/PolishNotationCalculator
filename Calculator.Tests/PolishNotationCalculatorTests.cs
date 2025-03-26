using Xunit;
using Calculator;

namespace Calculator.Tests
{

    public class PolishNotationCalculatorTests
    {
        private readonly IPolishNotationCalculator _calculator
            = new PolishNotationCalculator();

        [Theory]
        [InlineData("+ 1 2", 3)]
        [InlineData("- 5 2", 3)]
        [InlineData("* 3 4", 12)]
        [InlineData("/ 10 2", 5)]
        public void GIVEN_two_operands_WHEN_calculate_THEN_return_result(
            string input, double expected)
        {
            var result = _calculator.Calculate(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("+ + 1 2 3", 6)]     // (1 + 2) + 3
        [InlineData("+ * 1 2 3", 5)]     // (1 * 2) + 3
        [InlineData("- / 10 2 1", 4)]    // (10 / 2) - 1
        public void GIVEN_three_operands_WHEN_calculate_THEN_return_result(
    string input, double expected)
        {
            var result = _calculator.Calculate(input);
            Assert.Equal(expected, result);
        }
    }
}