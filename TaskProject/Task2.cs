using System;
using System.Text.RegularExpressions;

namespace TaskProject
{
    /// <summary>
    /// Задание 2
    /// </summary>
    public static class Task2
    {
        /// <summary>
        /// Вычисление суммы всех чисел, содержащихся в строке
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>Сумма всех чисел, содержащихся в строке</returns>
        /// <remarks>
        /// Предполагается, что число может быть целым
        /// (тогда оно не содержит десятичной точки)
        /// и вещественным 
        /// (тогда оно содержит целую и дробную часть, 
        /// каждая из которых содержит по крайней мере одну цифру,
        /// а разделителем частей является точка)
        /// </remarks>
        public static double CalculateSum(string str)
        {
            double res = 0.0;
            Regex regex = new Regex(@"-?\d+(\.\d+)?");
            MatchCollection matches = regex.Matches(str);
            if (matches.Count == 0)
                return 0.0;
            foreach (Match match in matches)
                res += Convert.ToDouble(match.Value, 
                    System.Globalization.CultureInfo.InvariantCulture);
            return res;
        }
    }
}
