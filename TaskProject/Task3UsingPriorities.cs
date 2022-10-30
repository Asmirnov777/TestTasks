using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskProject
{
    /// <summary>
    /// Вариант решения задания 3 с помощью нескольких проходов по списку,
    /// число которых равно числу рассматриваемых приоритетов операций
    /// </summary>
    /// <remarks>
    /// Данную реализацию целесообразно использовать, 
    /// если в будущем возможно появление новых операций с другими приоритетами 
    /// (например, возведение в степень)
    /// </remarks>
    public class Task3UsingPriorities : Task3
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
                // Число строк должно быть нечетным
                if (strArr.Length % 2 == 0)
                    throw new TasksException("Неверное число строк в массиве");

                // ФОрмирование списка чисел и списка операций
                List<string> operList = strArr.Where((x, i) => i % 2 == 1 && x.Length == 1).ToList();
                List<double> numList = strArr.Where((y, i) => i % 2 == 0).Select(x => getNum(x)).ToList();
                if (operList.Count != numList.Count - 1)
                    throw new TasksException("В качестве операций могут использоваться только строки из одного символа");

                // Цикл по приоритетам операций
                foreach (string opers in operatorsSorted)
                {
                    int i = 0;
                    // Проход по списку операций
                    while (i < operList.Count)
                    {
                        // Если список операций не уменьшился так, что i вышел за его пределы,
                        // а текущая операция имеет рассматриваемый приоритет
                        while (i < operList.Count && opers.Contains(operList[i]))
                        {
                            // Вычислить и записать результат на место левого операнда
                            numList[i] = operations[operList[i]](numList[i], numList[i + 1]);
                            // Удалить правый операнд из списка
                            numList.RemoveAt(i + 1);
                            // Удалить операцию из списка
                            operList.RemoveAt(i);
                        }
                        i++;
                    }
                }

                // В результате список чисел должен содержать 1 элемент - 
                // результат вычисления всего выражения
                // (а список операторов должен оказаться пустым).
                // Если это не так, то какие-то операции не удалось распознать.
                if (numList.Count != 1)
                {
                    string errMes = "В качестве операций не могут использоваться символы:";
                    foreach (var s in operList)
                        errMes += " " + s;
                    throw new TasksException(errMes);
                }
                
                return numList[0];
            }

            catch (DivideByZeroException e)
            {
                throw new TasksException("Деление на ноль", e);
            }
        }

        /// <summary>
        /// Перевод числа из строкового представления в вещественное
        /// </summary>
        /// <param name="strArr">Строка</param>
        /// <returns>Вещественное число</returns>
        private static double getNum(string str)
        {
            if (!int.TryParse(str, out int num))
                throw new TasksException($"Строка {str} не является целым числом");
            return (double)num;
        }

    }
}
