using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static OOP_Lesson8.Const;

namespace OOP_Lesson8
{
    public class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args).Build();
            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
            var pageSize = config.GetValue<int>("PageSize");
            var methods = new Methods(pageSize);

            string showInfo =
                               $"{Environment.NewLine}{Keys.Info} - справка" +
                               $"{Environment.NewLine}{Keys.PagingOutput} - постраничный вывод дерева " +
                               $"{Environment.NewLine}{Keys.CopyFolder} - копирование каталога" +
                               $"{Environment.NewLine}{Keys.CopyFile} - копирование файла" +
                               $"{Environment.NewLine}{Keys.RemoveFolder} - удаление каталога" +
                               $"{Environment.NewLine}{Keys.RemoveFile} - удаление файла" +
                               $"{Environment.NewLine}{Keys.FolderInfo} - информация о каталоге" +
                               $"{Environment.NewLine}{Keys.FileInfo} - информация о файле";

            var keys = new[]
            {
                Keys.Info,
                Keys.PagingOutput,
                Keys.CopyFolder,
                Keys.CopyFile,
                Keys.RemoveFolder,
                Keys.RemoveFile,
                Keys.FolderInfo,
                Keys.FileInfo
            };

            Console.WriteLine("Путь к файлу или каталогу:");
            var path = Console.ReadLine();
            var result = new List<string> { };
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Папки по указанному пути не существует");
            }
            else
            {
                result = Methods.GetContentsFromFolderRecursive(path, 0, 2);

                var cutresult = methods.CutResultsToRange(result, 1);

                foreach (var resultValue in cutresult.result)
                {
                    Console.WriteLine(resultValue);
                }

            }

            Console.WriteLine(showInfo);

            var exit = false;

            while (!exit)
            {
                var userLine = Console.ReadLine();
                var userValues = userLine.Split(' ');//получаем ключ и значение (-я) ключа, введенные пользователем
                var userKey = userValues.First();
                if (!keys.Contains(userKey))
                {
                    Console.WriteLine($"Не удалось определить команду {userValues.First()}");
                }
                else
                {
                    switch (userKey)
                    {
                        case Keys.Info:
                            Console.WriteLine(showInfo);
                            break;

                        case Keys.PagingOutput:
                            var (userInputIsCorrect, userKeyValue) = Methods.CheckErrorsForUserInput(userValues);
                            if (!userInputIsCorrect)
                            {
                                break;
                            }
                            if (!int.TryParse(userKeyValue, out int parsedUserKeyValue))
                            {
                                Console.WriteLine($"Не удалось определить значение ключа {userKeyValue}");
                                break;
                            }
                            var cutResult = methods.CutResultsToRange(result, parsedUserKeyValue);
                            foreach (var resultValue in cutResult.result)
                            {
                                Console.WriteLine(resultValue);
                            }
                            break;

                        case Keys.CopyFolder:
                            var (inputIsCorrect, source, dest) = Methods.CheckErrorsForCopy(userValues);
                            if (!inputIsCorrect)
                            {
                                break;
                            }
                            if (!Directory.Exists(source))
                            {
                                Console.WriteLine($"Папки по указанному пути {source} не существует");
                                break;
                            }
                            if (Directory.Exists(dest))
                            {
                                Console.WriteLine($"Папка по указанному пути {dest} уже существует");
                                break;
                            }
                            Directory.Move(source, dest);
                            break;

                        case Keys.CopyFile:
                            (inputIsCorrect, source, dest) = Methods.CheckErrorsForCopy(userValues);
                            if (!inputIsCorrect)
                            {
                                break;
                            }
                            if (!File.Exists(source))
                            {
                                Console.WriteLine("Файла(-ов) по указанному(-ым) пути(-ям) не существует");
                                break;
                            }
                            if (Directory.Exists(dest))
                            {
                                Console.WriteLine("Должен быть указан файл, а не каталог");
                                break;
                            }
                            File.Copy(source, dest);
                            break;

                        case Keys.RemoveFolder:
                            (userInputIsCorrect, userKeyValue) = Methods.CheckErrorsForFolder(userValues);
                            if (!userInputIsCorrect)
                            {
                                break;
                            }
                            Directory.Delete(userKeyValue, true);
                            break;

                        case Keys.RemoveFile:
                            (userInputIsCorrect, userKeyValue) = Methods.CheckErrorsForFile(userValues);
                            if (!userInputIsCorrect)
                            {
                                break;
                            }
                            File.Delete(userKeyValue);
                            break;

                        case Keys.FolderInfo:
                            (userInputIsCorrect, userKeyValue) = Methods.CheckErrorsForFolder(userValues);
                            if (!userInputIsCorrect)
                            {
                                break;
                            }
                            Methods.PrintFolderInfo(userKeyValue);
                            break;

                        case Keys.FileInfo:
                            (userInputIsCorrect, userKeyValue) = Methods.CheckErrorsForFile(userValues);
                            if (!userInputIsCorrect)
                            {
                                break;
                            }
                            Methods.PrintFileInfo(userKeyValue);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
