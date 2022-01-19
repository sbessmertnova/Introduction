using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Как тебя зовут?\n");
            string userName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"Привет, {userName}!\nCегодня {DateTime.Now.ToShortDateString()} г.");
            Console.ReadKey();
        }
    }
}
