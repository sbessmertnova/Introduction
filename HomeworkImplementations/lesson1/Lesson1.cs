using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkImplementations.lesson1
{
    public class Lesson1
    {
        public static void Task1()
        {
            Console.WriteLine("Введите число");
            int.TryParse(Console.ReadLine(), out int number);
            if (PrimeNumberChecker.IsPrimeNumber(number))
            {
                Console.WriteLine("Введенное число простое");
            }
            else
            {
                Console.WriteLine("Введенное число не простое");
            }

            TestOutPut(1, "TestCase1 positive");
            TestOutPut(2, "TestCase2 positive");
            TestOutPut(4, "TestCase1 negative", false);
            TestOutPut(9, "TestCase2 negative", false);
            TestOutPut(7, "TestCase3 positive");
        }
        public static void Task2()
        {
            Console.WriteLine("Асимптотическая сложность функции: O(N3)");
        }
        public static void Task3()
        {
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

        public static void TestOutPut(int number, string outPutText, bool expectedTrue = true)
        {
            Console.WriteLine($"{outPutText}");
            if (expectedTrue ?
                PrimeNumberChecker.IsPrimeNumber(number)
                : !PrimeNumberChecker.IsPrimeNumber(number))
            {
                Console.WriteLine($"\nTest with test number {number} passed");
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
