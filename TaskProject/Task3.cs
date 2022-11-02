using System;
using System.Collections.Generic;

namespace TaskProject
{
    public static class Task3
    {
        /// <summary>
        /// Вычисление выражения в польской нотации
        /// </summary>
        /// <param name="strArr">Массив строк, заполненный целыми числами и операторами +, -, *, /</param>
        /// <returns>Результат вычисления выражения</returns>
        public static double CalculateExpression(string[] strArr)
        {
            if (strArr == null)
                throw new TasksException("Список пуст");
            double result = calculateWhileItCanBe(strArr, 0, out int endIndex);
            if (endIndex != strArr.Length - 1)
                throw new TasksException("Выражение введено неверно (в массиве лишние строки)");
            return result;
        }

        private static double calculateWhileItCanBe(string[] strArr, int startIndex, out int endIndex)
        {
            if (startIndex >= strArr.Length)
                throw new TasksException("Выражение введено неверно (в массиве не хватает строк)");

            if (operations.ContainsKey(strArr[startIndex]))
            { // текущая строка - операция
                double leftOperand = calculateWhileItCanBe(strArr, startIndex + 1, out int leftEndIndex),
                    rightOperand = calculateWhileItCanBe(strArr, leftEndIndex + 1, out endIndex);
                return operations[strArr[startIndex]](leftOperand, rightOperand);
            }
            else
            { // текущая строка - число
                endIndex = startIndex;
                return getNum(strArr, startIndex);
            }
        }


        /// <summary>
        /// Словарь операций
        /// </summary>
        private static readonly Dictionary<string, Func<double, double, double>>
            operations = new Dictionary<string, Func<double, double, double>>()
            {
                {"+", (x, y) => x + y },
                {"-", (x, y) => x - y },
                {"*", (x, y) => x * y },
                {"/", (x, y) => x / y },
            };

        /// <summary>
        /// Перевод числа из строкового представления в вещественное
        /// </summary>
        /// <param name="strArr">Массив строк</param>
        /// <param name="i">Элемент массива строк, который требуется перевести в число</param>
        /// <returns>Вещественное число</returns>
        private static double getNum(string[] strArr, int i)
        {
            if (!int.TryParse(strArr[i], out int num))
                throw new TasksException($"{i}-й элемент массива не является целым числом");
            return (double)num;
        }
    }
}
