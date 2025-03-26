namespace Calculator
{
    public class PolishNotationCalculator : IPolishNotationCalculator
    {
        public double Calculate(string expression)
        {
            var tokens = expression.Split(' ');
            if (tokens.Length != 3)
                throw new ArgumentException("Invalid expression format");

            return tokens[0] switch
            {
                "+" => double.Parse(tokens[1]) + double.Parse(tokens[2]),
                "-" => double.Parse(tokens[1]) - double.Parse(tokens[2]),
                "*" => double.Parse(tokens[1]) * double.Parse(tokens[2]),
                "/" => double.Parse(tokens[1]) / double.Parse(tokens[2]),
                _ => throw new ArgumentException($"Unknown operator: {tokens[0]}")
            };
        }
    }
}