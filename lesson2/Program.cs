using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            Console.WriteLine("Введите максимальную температуру за сутки");
            var maxTemp = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите минимальную температуру за сутки");
            var minTemp = double.Parse(Console.ReadLine());
            var avgTemp = (maxTemp + minTemp)/2;
            Console.WriteLine($"Среднесуточная температура: {avgTemp}");

            //Задание 2
            Console.WriteLine("Введите порядковый номер текущего месяца");
            var currentMonthNumber = int.Parse(Console.ReadLine());
            var userDate = new DateTime(1, currentMonthNumber, 1);
            Console.WriteLine($"Введенный месяц: {userDate.ToString("MMMM")}");
            Console.ReadKey();
            //Задание 5
            if ((currentMonthNumber <= 2
                || currentMonthNumber == 12)
                && avgTemp > 0)
            {
                Console.WriteLine("Дождливая зима");
            }
            //Задание 3
            Console.WriteLine("Введите число");
            var userNumber = int.Parse(Console.ReadLine());
            if (userNumber % 2 == 0)
            {
                Console.WriteLine("Введенное число четное");
            }
            else
            {
                Console.WriteLine("Введенное число нечетное");
            }
            Console.ReadKey();
            //Задание 4
            var date = DateTime.Now;
            var goods = new List<(string, decimal)>
            {
                ("apple", 54.5m),
                ("bread", 45),
                ("milk", 86.5m),
                ("cheese", 250.9m)
            };
            Console.WriteLine($"{Environment.NewLine}");
            Console.WriteLine($"{date}{Environment.NewLine}");
            foreach (var good in goods)
            {
                Console.WriteLine($"{good.Item1.PadRight(15, '.')}{good.Item2,-5}{Environment.NewLine}");
            }
            var summ = goods.Select(good => good.Item2).Sum();
            Console.WriteLine("_______________");
            Console.WriteLine($"Сумма:".PadRight(15, '.') + summ);
            Console.ReadKey();
        }
    }
}
