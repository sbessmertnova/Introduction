using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lesson5
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Задание 1
            Console.WriteLine("Задание 1");
            var data = Console.ReadLine();
            File.AppendAllText("Task1.txt", data);
            //Задание 2
            Console.WriteLine("Задание 2");
            var currentDateTime = DateTime.Now.TimeOfDay;
            File.AppendAllText("startup.txt", currentDateTime.ToString());
            //Задание 3
            Console.WriteLine("Задание 3");
            data = Console.ReadLine();
            using var stream = File.Open("Task3.bin", FileMode.OpenOrCreate);
            using var writer = new BinaryWriter(stream, Encoding.UTF8, false);
            writer.Write(data);
            //Задание 5
            string fileName = "Task5.json";
            var tasks = new List<ToDo>()
            {
                new ToDo{Title="ToDo1", IsDone = true},
                new ToDo{Title="ToDo2", IsDone = false},
                new ToDo{Title="ToDo3", IsDone = true},
            };
            if (File.Exists(fileName))
            {
                using FileStream openStream = File.OpenRead(fileName);
                tasks =
                     await JsonSerializer.DeserializeAsync<List<ToDo>>(openStream);
            }
            var numberedTasks = tasks.Select((task, i) => (i, task));
            foreach (var (i, task) in numberedTasks)
            {
                Console.WriteLine($"{i} {(task.IsDone ? "x" : "")} {task.Title}");
            }
            Console.WriteLine("Input task no");
            var userInput = Console.ReadLine();
            tasks[int.Parse(userInput)].IsDone = true;
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync(createStream, tasks);
        }
    }
}
