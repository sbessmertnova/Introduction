using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            string secret = "123456";
            Console.WriteLine("Введите пароль");
            string input = Console.ReadLine();
            if (input == secret)
            {
                Console.WriteLine("Пароль верный");
            }

        }
    }
}
