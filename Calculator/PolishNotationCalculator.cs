using System;
using System.Collections.Generic;

namespace Calculator
{
    public class PolishNotationCalculator
    {
        public double Calculate(string expression)
        {
            var tokens = expression.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var stack = new Stack<double>();

            for (int i = tokens.Length - 1; i >= 0; i--)
            {
                if (double.TryParse(tokens[i], out var num))
                {
                    stack.Push(num);
                }
                else
                {
                    var a = stack.Pop();
                    var b = stack.Pop();
                    stack.Push(ApplyOperator(tokens[i], a, b));
                }
            }

            return stack.Pop();
        }

        private double ApplyOperator(string op, double a, double b)
        {
            return op switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => b != 0 ? a / b : throw new DivideByZeroException(),
                _ => throw new ArgumentException($"Unknown operator: {op}")
            };
        }
    }
}