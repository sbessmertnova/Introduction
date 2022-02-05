using System;
using System.Collections.Generic;
using System.Linq;
namespace lesson4
{
    class Program
    {
        public enum YearTimes
        {
            Winter,
            Spring,
            Summer,
            Autumn
        }
        static void Main(string[] args)
        {
            //Задание 1
            var firstFIO = new List<string>()
            {
                "Котин",
                "Вячеслав",
                "Андреевич"
            };
            var secondFIO = new List<string>()
            {
                "Лисовая",
                "Светлана",
                "Алексеевна"
            };
            var thirdFIO = new List<string>()
            {
                "Зайцева",
                "Наталья",
                "Александровна"
            };
            Console.WriteLine($"{GetFullName(firstFIO[0], firstFIO[1], firstFIO[2])}");
            Console.WriteLine($"{GetFullName(secondFIO[0], secondFIO[1], secondFIO[2])}");
            Console.WriteLine($"{GetFullName(thirdFIO[0], thirdFIO[1], thirdFIO[2])}");
            Console.ReadKey();
            
            //Задание 2
            Console.WriteLine("Введите числа через пробел");
            var userInput = Console.ReadLine();
            var inputNumbrs = userInput.Split(' ');
            var parsedNumbers = inputNumbrs.Select(number => int.Parse(number)).ToList();
            var sum = 0;
            for (var i = 0; i < parsedNumbers.Count; i++)
            {
                sum += parsedNumbers[i];
            }
            Console.WriteLine($"Сумма введенных чисел: {sum}");
            Console.ReadKey();

            //Задание 3
            Console.WriteLine("Введите номер месяца");
            userInput = Console.ReadLine();
            var parsedUserInput = int.Parse(userInput);
            if (parsedUserInput<=12 && parsedUserInput!=0)
            {
                var yearTime = FindYearTime(parsedUserInput);
                Console.WriteLine($"Время года - {GetYearTimeName(yearTime)}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Ошибка: введите число от 1 до 12");
            }  
        }
        public static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{firstName} {lastName} {patronymic}";
        }
        public static YearTimes FindYearTime(int monthNumber)
        {
            if(monthNumber <= 2 || monthNumber ==12                )
            {
                return YearTimes.Winter;
            }
            if(monthNumber <= 5)
            {
                return YearTimes.Spring;
            }
            if (monthNumber <= 8)
            {
                return YearTimes.Summer;
            }
            return YearTimes.Autumn;
        }
        public static string GetYearTimeName(YearTimes yearTime)
        {
            var YearTimeNames = new Dictionary<YearTimes, string>
            {
                {YearTimes.Autumn, "осень"},
                {YearTimes.Spring, "весна"},
                {YearTimes.Summer, "лето"},
                {YearTimes.Winter, "зима"},
            };
           return YearTimeNames.GetValueOrDefault(yearTime);
        }
    }
}
