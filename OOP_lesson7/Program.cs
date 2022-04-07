using System;

namespace OOP_lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            var acoder = new ACoder();
            Console.WriteLine($"{acoder.Encode("крыска")}");
            Console.WriteLine($"{acoder.Decode("лсьтлб")}");
            var bcoder = new BCoder();
            Console.WriteLine($"{bcoder.Encode("Алиска")}");
            Console.WriteLine($"{bcoder.Decode("Яфчохя")}");

            Console.ReadKey();

        }

    }
}
