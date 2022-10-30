using System;
using System.Collections.Generic;

namespace TaskProject
{
    public abstract class Task3
    {
        /// <summary>
        /// Вычисление выражения в польской нотации
        /// </summary>
        /// <param name="strArr">Массив строк, заполненный целыми числами и операторами +, -, *, /</param>
        /// <returns>Результат вычисления выражения</returns>
        public abstract double CalculateExpression(string[] strArr);

        /// <summary>
        /// Символы операторов, отсортированные по приоритетам
        /// </summary>
        protected static readonly string[]
            operatorsSorted = new string[] { "*/", "+-" };

        /// <summary>
        /// Словарь операций
        /// </summary>
        protected static readonly Dictionary<string, Func<double, double, double>>
            operations = new Dictionary<string, Func<double, double, double>>()
            {
                {"+", (x, y) => x + y },
                {"-", (x, y) => x - y },
                {"*", (x, y) => x * y },
                {"/", (x, y) => x / y },
            };

    }
}
