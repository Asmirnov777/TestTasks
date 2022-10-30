using System;

namespace TaskProject
{
    /// <summary>
    /// Вариант решения задания 3 за один проход массива
    /// </summary>
    /// <remarks>
    /// Преимуществом данного варианта является скорость работы
    /// </remarks>
    public class Task3OnePass : Task3
    {
        /// <summary>
        /// Вычисление выражения в польской нотации
        /// </summary>
        /// <param name="strArr">Массив строк, заполненный целыми числами и операторами +, -, *, /</param>
        /// <returns>Результат вычисления выражения</returns>
        public override double CalculateExpression(string[] strArr)
        {
            try
            {
                if (strArr == null)
                    throw new TasksException("Список пуст");
                int length = strArr.Length;
                // Число строк должно быть нечетным
                if (length % 2 == 0)
                    throw new TasksException("Неверное число строк в массиве");

                double leftOperand = getNum(strArr, 0);

                if (length > 1)
                {
                    for (int i = 1; i < length; i += 2)
                    {
                        double rightOperand = getNum(strArr, i + 1);
                        switch (strArr[i])
                        {
                            // Если операторы * или / идут вначале,
                            // то применить их сразу к вычисленной части выражения
                            case "*":
                            case "/":
                                leftOperand = operations[strArr[i]](leftOperand, rightOperand);
                                break;

                            case "+":
                            case "-":
                                var operation = operations[strArr[i]];
                                // Если текущий оператор + или - не последний
                                if (i < length - 2)
                                {
                                    // Если за ним идут операторы * или /,
                                    // то сначала вычислить правый операнд
                                    int j = i + 2;
                                    while (j < length && (strArr[j] == "*" || strArr[j] == "/"))
                                    {
                                        double thirdOperand = getNum(strArr, j + 1);
                                        rightOperand = operations[strArr[j]](rightOperand, thirdOperand);
                                        i = j;
                                        j += 2;
                                    }
                                }
                                leftOperand = operation(leftOperand, rightOperand);
                                break;
                            default:
                                throw new TasksException($"{i}-й элемент массива строк не является разрешенной операцией (+, -, *, /)");
                        }
                    }
                }
                return leftOperand;
            }
            catch (DivideByZeroException e)
            {
                throw new TasksException("Деление на ноль", e);
            }
        }

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
