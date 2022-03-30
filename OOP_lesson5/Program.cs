using System;
namespace OOP_lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1 - in RationalNumber.cs
            //Task2                
            Complex complex1 = new(1, 1);
            Complex complex2 = new(3, 4);
            Console.Write("\nДемонстрация работы вычитания - 1; \nДемонстрация работы умножения - 2; " +
            "\nВыберите нужный номер: ");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.WriteLine($"Разность двух комплексных чисел {complex1} и {complex2} с использованием метода класса: " + Complex.Subtract(complex1, complex2).ToString());
                    break;
                case 2:
                    Console.WriteLine($"Произведение двух комплексных чисел {complex1} и {complex2} с использованием метода класса: " + Complex.Multi(complex1, complex2).ToString());
                    break;
                default:
                    Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                    break;
            }
        }
    }
}
