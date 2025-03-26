namespace Calculator
{
    public interface IPolishNotationCalculator
    {
        /// <summary>Вычисляет выражение в польской нотации</summary>
        /// <param name="expression">Например: "+ 1 2"</param>
        /// <exception cref="ArgumentException">При невалидном выражении</exception>
        double Calculate(string expression);
    }
}