using System;

namespace TaskProject
{
    class Program
    {

        static void Main(string[] args)
        {
            string inStr = Console.ReadLine();
            string commonStart = Task1.DefineCommonStart(inStr);
            Console.WriteLine(commonStart);
        }
    }
}
