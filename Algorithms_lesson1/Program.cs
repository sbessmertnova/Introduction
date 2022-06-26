﻿using Algorithms_lesson1.lesson3;
using Algorithms_lesson1.lesson4;
using System;

namespace Algorithms_lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите урок");
            bool f = true;
            while (f)
            {
                Console.Write("Урок №1 - 1; \nУрок №2 - 2" +
                    "\nУрок №3 - 3; " +
                    "\nУрок №4 - 4; " +
                    "\nУрок №5 - 5; " +
                    //"\nУрок №6 - 6; \nУрок №7 - 7; \nУрок №8 - 8;" +
                    " \nЗавершить - 0;" +
                    "\nРешение какого урока запустить? Введите соответствующее число: ");
                int lessonNumber = int.Parse(Console.ReadLine());
                switch (lessonNumber)
                {
                    case 1:
                        Console.WriteLine("Выберите номер задания \n1 - нажмите 1; \n2 - нажмите 2;  \n3 - нажмите 3;" +
                            "\nРешение какого задания запустить? Введите соответствующее число: ");
                        var userNumber = int.Parse(Console.ReadLine());
                        switch (userNumber)
                        {
                            case 1:
                                Console.WriteLine("Выполнение 1 задания. ");
                                Lesson1.Task1();
                                break;
                            case 2:
                                Console.WriteLine("Выполнение 2 задания. ");
                                Lesson1.Task2();
                                break;
                            case 3:
                                Console.WriteLine("Выполнение 3 задания. ");
                                Lesson1.Task3();
                                break;
                            default:
                                Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Выполнение задания 2 урока");
                        Node.Test();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Выполнение задания 3 урока");
                        PointsLengthTests.Tests();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Выполнение задания 4 урока");
                        NodeTest.TestNode();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Выполнение задания 5 урока");
                        SearchNodeTests.TestNode();
                        break;

                    case 0:
                        Console.WriteLine("Завершение");
                        f = false;
                        break;
                    default:
                        Console.WriteLine("Вы ввели некорректное число. Попробуйте снова");
                        break;
                }
            }

        }

    }
}


