using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator
{

    public class PolishNotationCalculator : IPolishNotationCalculator
    {
        public double Calculate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("Expression cannot be empty");

            // Удаляем скобки и лишние пробелы
            var cleaned = expression
                .Replace("(", " ")
                .Replace(")", " ")
                .Replace("  ", " ");

            var tokens = cleaned.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<double>();

            // Обрабатываем токены в обратном порядке
            for (int i = tokens.Length - 1; i >= 0; i--)
            {
                if (double.TryParse(tokens[i], out var num))
                {
                    stack.Push(num);
                }
                else
                {
                    if (stack.Count < 2)
                        throw new ArgumentException($"Not enough operands for operator: {tokens[i]}");

                    var a = stack.Pop();
                    var b = stack.Pop();
                    stack.Push(ApplyOperator(tokens[i], a, b));
                }
            }

            if (stack.Count != 1)
                throw new ArgumentException("Invalid expression format");

            return stack.Pop();
        }

        private double ApplyOperator(string op, double a, double b) => op switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => b != 0 ? a / b : throw new DivideByZeroException(),
            _ => throw new ArgumentException($"Unknown operator: {op}")
        };
    }
}