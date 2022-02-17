using System;
using System.Diagnostics;
using System.Linq;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            var allProcesses = Process.GetProcesses().OrderBy(process=>process.ProcessName);
            foreach (var process in allProcesses)
            {
                Console.WriteLine($"Id: {process.Id} Имя: {process.ProcessName}");
            }
            Console.WriteLine("Введите Id процесса: ");
            var selectedProcess = Console.ReadLine();
            try
            {
                var parsed = int.TryParse(selectedProcess, out var result);
                if (!parsed)
                {
                    throw new FormatException($"Failed to parse user input ({selectedProcess})");
                }
                var processForKill = Process.GetProcessById(int.Parse(selectedProcess));
                processForKill.Kill();
            }
            catch (FormatException x)
            {
                Console.Write($"Введенное значение не является числом");
            }
            catch (ArgumentException)
            {
                Console.Write($"Некорректный id");
            }
        }
    }
}
