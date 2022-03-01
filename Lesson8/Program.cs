using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine
                (
                Properties.Settings.Default.Hello +
                Properties.Settings.Default.Name +
                Properties.Settings.Default.Age +
                Properties.Settings.Default.Work 
                );

            Console.ReadKey();
            Console.WriteLine("Твое имя:");
            Properties.Settings.Default.Name = Console.ReadLine();
            Properties.Settings.Default.Save();

            Console.WriteLine("Твой возраст:");
            Properties.Settings.Default.Age = Console.ReadLine();
            Properties.Settings.Default.Save();

            Console.WriteLine("Твой род деятельности:");
            Properties.Settings.Default.Work = Console.ReadLine();
            Properties.Settings.Default.Save();

        }
    }
}
