using System;

namespace Algorithms_lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            Console.WriteLine("Введите число");
            int.TryParse(Console.ReadLine(), out int number);
            if (IsPrimeNumber(number))
            {
                Console.WriteLine("Введенное число простое");
            }
            else
            {
                Console.WriteLine("Введенное число не простое");
            }

            //TestCase1 positive
            TestOutPut(1);
            //TestCase2 positive
            TestOutPut(2);
            //TestCase3 positive
            TestOutPut(7);
            //TestCase1 negative
            TestOutPut(4, false);
            //TestCase2 negative
            TestOutPut(9, false);

            //Задание 2
            //Асимптотическая сложность функции: O(N3)

            //Задание 3
            //Рекурсия:

            var test1 = ColculateFibonachi(2);
            var test2 = ColculateFibonachi(4);
            var test3 = ColculateFibonachi(7);

            Console.WriteLine($"Для 2 число Фибоначчи = {test1}");
            Console.WriteLine($"Для 4 число Фибоначчи = {test2}");
            Console.WriteLine($"Для 7 число Фибоначчи = {test3}");

            //Цикл:
            var test4 = ColculateFibonachi(2);
            var test5 = ColculateFibonachi(4);
            var test6 = ColculateFibonachi(7);

            Console.WriteLine($"Для 2 число Фибоначчи = {test4}");
            Console.WriteLine($"Для 4 число Фибоначчи = {test5}");
            Console.WriteLine($"Для 7 число Фибоначчи = {test6}");
            Console.ReadKey();
        }
        public static bool IsPrimeNumber(int number)
        {
            int d = 0;
            for (int i = 2; i < number; i++)
            {
                if (number%i==0)
                {
                    d++;
                }
            }
            if (d == 0)
            {
                return true;
            }
            else return false;
        }
        public static void TestOutPut(int number, bool expectedTrue = true)
        {

            if (expectedTrue ?
                IsPrimeNumber(number)
                : !IsPrimeNumber(number))
            {
                Console.WriteLine($"Test with test number {number} passed");
            }
            else
            {
                Console.WriteLine($"Test with test number {number} failed");
            }


        }
        public static int ColculateFibonachi(int number)
        {
            if (number == 0 || number == 1) return number;

            return ColculateFibonachi(number - 1) + ColculateFibonachi(number - 2);
        }

        public static int ColculateFibonachi2(int number)
        {
            int result = 0;
            int a = 1;
            int temp;

            for (int i = 0; i < number; i++)
            {
                temp = result;
                result = a;
                a += temp;
            }
            return result;
        }


    }
}

