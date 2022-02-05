using System;
using System.Linq;
namespace lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            var square = new int[5, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 }, { 21, 22, 23, 24, 25 } };
            OutputSquare(square);
            Console.ReadKey();
            //Задание 2
            var phoneBook = new string [5, 2] 
            { 
                { "Котин Вячеслав", "12345" }, 
                { "Лисовая Светлана", "23456" }, 
                { "Зайцева Наталья", "34567" }, 
                { "Уткин Михаил", "45678" }, 
                { "Кузнецов Дмитрий", "56789" } 
            };
            OutputPhoneBook(phoneBook);
            Console.ReadKey();
            //Задание 3
            Console.WriteLine("Введите строку");
            var userInput = Console.ReadLine();
            Console.WriteLine($"{new string (userInput.Reverse().ToArray())}");
            Console.ReadKey();
        }
        public static void OutputSquare (int[,] square)
        {
            for (int i = 0; i <= square.GetUpperBound(0); i++)
            {
                Console.WriteLine($"{square[i, i]}");
            }
        }
        public static void OutputPhoneBook(string[,] phoneBook)
        {
            for (int i = 0; i <= phoneBook.GetUpperBound(0); i++)
            {
                Console.WriteLine($"{phoneBook[i, 0]}: {phoneBook[i, 1]}");
            }
        }
    }
}
