using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_9
{
   public static class Methods
    {
        /// <summary>
        /// обрабатывает ошибки, которые могут возникнуть в операциях с каталогами
        /// </summary>
        /// <param name="userValues">введенные пользователем данные</param>
        /// <returns></returns>
        public static (bool userInputIsCorrect, string userKeyValue) CheckErrorsForFolder(string[] userValues)
        {
            var (userInputIsCorrect, userKeyValue) = CheckErrorsForUserInput(userValues);
            if (!userInputIsCorrect)
            {
                return (false, null);
            }
            if (!Directory.Exists(userKeyValue))
            {
                Console.WriteLine($"Папки по указанному пути {userKeyValue} не существует");
                return (false, null);
            }
            return (true, userKeyValue);
        }
        /// <summary>
        /// обрабатывает ошибки, которые могут возникнуть в операциях с файлами
        /// </summary>
        /// <param name="userValues">введенные пользователем данные</param>
        /// <returns></returns>
        public static (bool userInputIsCorrect, string userKeyValue) CheckErrorsForFile(string[] userValues)
        {
            var (userInputIsCorrect, userKeyValue) = CheckErrorsForUserInput(userValues);
            if (!userInputIsCorrect)
            {
                return (false, null);
            }
            if (!File.Exists(userKeyValue))
            {
                Console.WriteLine($"Файла по указанному пути {userKeyValue} не существует");
                return (false, null);
            }
            return (true, userKeyValue);
        }
        /// <summary>
        /// обрабатывает ошибки, которые могут возникнуть при неправильном пользовательском вводе данных
        /// </summary>
        /// <param name="userValues">введенные пользователем данные</param>
        /// <returns></returns>
        public static (bool, string) CheckErrorsForUserInput(string[] userValues)
        {
            if (!KeyFirstValueExist(userValues))
            {
                return (false, null);
            }
            var userKeyValue = CheckUserKeyFirstValue(userValues).Item2;
            if (userValues.Length > 2)
            {
                Console.WriteLine($"{userValues.Length} значений у ключа. У ключа может быть только одно значение");
                return (false, null);
            }
            return (true, userKeyValue);
        }
        /// <summary>
        /// проверяет наличие значения у ключа и получает это значение
        /// </summary>
        /// <param name="userValues">введенные пользователем данные</param>
        /// <returns></returns>
        public static (bool, string) CheckUserKeyFirstValue(string[] userValues)
        {
            if (!userValues.Skip(1).Any() || !userValues.Skip(1).First().Any())
            {
                return (false, null);
            }
            return (true, userValues.Skip(1).First());
        }
        /// <summary>
        /// проверяет наличие у ключа значения, пишет сообщение об ошибке, если значения нет
        /// </summary>
        /// <param name="userValues">введенные пользователем данные</param>
        /// <returns></returns>
        public static bool KeyFirstValueExist(string[] userValues)
        {
            if (!CheckUserKeyFirstValue(userValues).Item1)
            {
                Console.WriteLine("У ключа нет значения");
                return false;
            }
            return true;
        }
        /// <summary>
        /// проверяет наличие у ключа второго значения и получает это значение
        /// </summary>
        /// <param name="userValues">введенные пользователем данные</param>
        /// <returns></returns>
        public static (bool, string) CheckUserKeySecondValue(string[] userValues)
        {
            if (!userValues.Skip(2).Any() || !userValues.Skip(2).First().Any())
            {
                return (false, null);
            }

            return (true,
                userValues.Skip(2).First());
        }
        /// <summary>
        /// проверяет наличие второго значения у ключа 
        /// и в случае его отсутствия пишет в консоль сообщение об ошибке
        /// </summary>
        /// <param name="userValues">введенные пользователем данные</param>
        /// <returns></returns>
        public static bool KeySecondValueExist(string[] userValues)
        {
            if (!CheckUserKeySecondValue(userValues).Item1)
            {
                Console.WriteLine("У ключа нет второго значения");
                return false;
            }
            return true;
        }
        /// <summary>
        /// обрабатывает ошибки, могущие возникнуть при копировании
        /// </summary>
        /// <param name="userValues"></param>
        /// <returns></returns>
        public static (bool inputIsCorrect, string sourse, string dest) CheckErrorsForCopy(string[] userValues)
        {
            if (!KeyFirstValueExist(userValues))
            {
                return (false, null, null);
            }
            if (!KeySecondValueExist(userValues))
            {
                return (false, null, null);
            }
            if (userValues.Length > 3)
            {
                Console.WriteLine($"{userValues.Length} значений у ключа. У ключа может быть только два значения");
                return (false, null, null);
            }
            var sourse = CheckUserKeyFirstValue(userValues).Item2;
            var dest = CheckUserKeySecondValue(userValues).Item2;
            return (true, sourse, dest);
        }
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="currentIndex"></param>
        ///// <param name="path"></param>
        //public static void PrintFiles(int currentIndex, string path)
        //{
        //    Console.Clear();
        //    string[] files = Directory.GetFiles(path);
        //    for (int i = 0; i < files.Length; i++)
        //    {
        //        if (currentIndex == i)
        //        {
        //            ConsoleColor current = Console.BackgroundColor;

        //            Console.BackgroundColor = ConsoleColor.Yellow;

        //            PrintFileInfo(files[i]);

        //            Console.BackgroundColor = current;

        //            continue;
        //        }
        //        PrintFileInfo(files[i]);
        //    }
        //}
        /// <summary>
        /// выводит в консоль информацию о файле
        /// </summary>
        /// <param name="file">путь до файла</param>
        public static void PrintFileInfo(string file)
        {
            FileInfo info = new FileInfo(file);

            Console.WriteLine($"{info.FullName} {info.Length} bytes. " +
                $"Last write time: {info.LastWriteTime}. From directory: {info.DirectoryName}" +
                $"Atributes: readonly - {info.IsReadOnly}, hidden - {info.Attributes.HasFlag(FileAttributes.Hidden)}");
        }
        /// <summary>
        /// выводит в консоль информацию о каталоге
        /// </summary>
        /// <param name="path">путь до каталога</param>
        public static void PrintFolderInfo(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);

            Console.WriteLine($"{info.FullName} {info.GetFiles().Length} files. " +
                $"Last write time: {info.LastWriteTime}. Creation time: {info.CreationTime}" +
                $"Atributes: readonly - {info.Attributes.HasFlag(FileAttributes.ReadOnly)}, hidden - {info.Attributes.HasFlag(FileAttributes.Hidden)}");
        }

        public static List<string> GetFileNamesFromFolder(string path)
        {
            return Directory.GetFiles(path).ToList();
        }
        /// <summary>
        /// получает каталоги из каталога
        /// </summary>
        /// <param name="path">путь до каталога</param>
        /// <returns></returns>
        public static List<string> GetFoldersFromFolder(string path)
        {
            if (Directory.Exists(path))
            {
                return Directory.GetDirectories(path).ToList();
            }
            return null;
        }

        public static List<string> GetContentsFromFolder(string path)
        {
            return GetFoldersFromFolder(path).Union(GetFileNamesFromFolder(path)).ToList();
        }
        /// <summary>
        /// получает содержимое каталога рекурсивно
        /// </summary>
        /// <param name="path">путь к каталогу</param>
        /// <param name="currentLevel">текущий уровень вложенности</param>
        /// <param name="maxLevel">максимальный уровень вложенности</param>
        /// <returns></returns>
        public static List<string> GetContentsFromFolderRecursive(string path, int currentLevel, int maxLevel)
        {

            var currentFolder = new List<string> { FormatNameForLevel(path, currentLevel) };
            var folders = GetFoldersFromFolder(path);
            if (currentLevel < maxLevel)
            {
                var folderResult = folders
                    .Select(folder => GetContentsFromFolderRecursive(folder, currentLevel + 1, maxLevel))
                    .SelectMany(result => result)
                    .ToList();
                currentFolder = currentFolder.Union(folderResult).ToList();
            }
            return currentFolder.Union(GetFileNamesFromFolder(path)
                .Select(fileName => FormatNameForLevel(fileName, currentLevel + 1))).ToList();
        }
        /// <summary>
        /// форматирует имя в имя с отступом (для вывода дерева)
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="level">количество tabs</param>
        /// <returns></returns>
        public static string FormatNameForLevel(string name, int level)
        {
            var tabs = string.Concat(Enumerable.Range(0, level).Select(i => "\t"));
            return $"{tabs} {name}";
        }
        /// <summary>
        /// определяет дианазон для пейджинга 
        /// </summary>
        /// <param name="pageNo"> номер страницы</param>
        /// <returns></returns>
        public static (int minValue, int pageSize) GetPagingRange(int pageNo)
        {
            var pageSize = Properties.Settings.Default.pageSize;
            var skipFiles = (pageSize * pageNo) - pageSize;
            return (skipFiles, pageSize);
        }
        /// <summary>
        /// обрезает до нужного диапазона 
        /// </summary>
        /// <param name="results">имена всех файлов и каталогов</param>
        /// <param name="pageNo">номер страницы</param>
        /// <returns></returns>
        public static (List<string> source, List <string> result) CutResultsToRange(List<string> results, int pageNo = 1)
        {
            var (minValue, pageSize) = GetPagingRange(pageNo);
            return (results,
                results.Skip(minValue).Take(pageSize).ToList());
        }
        ///// <summary>
        ///// выводит дерево каталога
        ///// </summary>
        ///// <param name="directory"></param>
        ///// <param name="level"></param>
        ///// <param name="maxLevel"></param>
        ///// <param name="page"></param>
        ///// <param name="currentPosition"></param>
        //public static void PrintDir(string directory, int level, int maxLevel, int page = 1,
        //    int currentPosition = 0)
        //{
        //    var pageSize = Properties.Settings.Default.pageSize;
        //    var skipFiles = (pageSize * page) - pageSize;
        //    var maxFileToShow = skipFiles + pageSize;

        //    try
        //    {
        //        string[] dirs = Directory.GetDirectories(directory);
        //        for (int i = 0; i < dirs.Length; i++)
        //        {
        //            currentPosition = i;
        //            if (currentPosition < skipFiles || currentPosition >= maxFileToShow)
        //            {
        //                break;
        //            }
        //            string childDir = dirs[i];
        //            WriteLeveledLine(childDir, level);
        //            PrintDir(childDir, level + 1, maxLevel);
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        Console.WriteLine($"Неправильная директория:{directory}");
        //    }
        //}
        ///// <summary>
        ///// выводит в консоль стороки с отступами
        ///// </summary>
        ///// <param name="value"></param>
        ///// <param name="levelNumber"></param>
        //private static void WriteLeveledLine(string value, int levelNumber)
        //{
        //    for (int z = 0; z < levelNumber; z++)
        //    {
        //        Console.Write("\t");
        //    }
        //    Console.WriteLine(value);
        //}

    }

}

