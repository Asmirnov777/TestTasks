namespace TaskProject
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public static class Task1
    {
        /// <summary>
        /// Поиск самого длинного общего начала нескольких строк
        /// </summary>
        /// <param name="inStr">Строка, содержащая слова через пробел</param>
        /// <returns>Самое длинное общее начало</returns>
        /// <remarks>
        /// Проверка на null и нулевое число элементов strArray не делается, так как:
        /// 1. введенная пользователем с консоли строка, даже пустая, не может быть null;
        /// 2. Split() всегда возвращает массив из как минимум одного элемента.
        /// </remarks>
        public static string DefineCommonStart(string inStr)
        {
            string[] strArray = inStr.Split(' ');
            string firstStr = strArray[0];
            int resLength = firstStr.Length,
                arrLength = strArray.Length;
            // Если введено одно слово, то вернуть его полностью
            if (arrLength == 1)
            {
                // При нулевой длине слова вернуть "-"
                if (firstStr.Length == 0)
                    return "-";
                return firstStr;
            }

            // Поиск общего начала первой строки со всеми остальными
            for (int i = 1; i < arrLength; i++)
            {
                // Найти длину общего начала нулевой строки с текущей
                string currentStr = strArray[i];
                int currentLength = getCommonCharsLength(firstStr, currentStr, resLength);
                // Если текущая длина общего начала уменьшилась,
                // то при сравнении следующих строк не искать дальше новой длины
                if (resLength > currentLength)
                    resLength = currentLength;
                // При нулевой длине общего начала вернуть "-"
                if (resLength == 0)
                    return "-";
            }

            return firstStr.Substring(0, resLength);
        }

        /// <summary>
        /// Поиск общего начала двух строк
        /// </summary>
        /// <param name="str1">Первая строка</param>
        /// <param name="str2">Вторая строка</param>
        /// <param name="maxLength">
        /// Максимальная длина общего начала, до которой следует производить поиск
        /// </param>
        /// <returns>Общее начало</returns>
        private static int getCommonCharsLength(string str1, string str2, int maxLength = int.MaxValue)
        {
            int length1 = str1.Length,
                length2 = str2.Length,
                length = 0;
            while (length < maxLength && length < length1 && length < length2)
            {
                if (str1[length] != str2[length])
                    return length;
                length++;
            }
            return length;
        }
    }
}
