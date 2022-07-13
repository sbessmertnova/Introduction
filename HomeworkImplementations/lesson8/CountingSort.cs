using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkImplementations.lesson8
{
    public class CountingSort
    {
        public static int[] Sort (int[] numbers)
        {
            return numbers
                .GroupBy(number => number)
                .OrderBy(numberGroup => numberGroup.Key)
                .Select(group=> Enumerable.Repeat(group.Key, group.Count()))
                .SelectMany(element => element).ToArray();
        }

        public static void Output()
        {
            var testData = new int[] { 1, 4, 3, 1, 1, 3, 3, 4, 4, 4, 4, 4, 1, 1, 1, 3, 1, 1 };
            Console.WriteLine($"Массив до сортировки: {string.Join(',', testData)}");
            Console.WriteLine($"Массив до сортировки: {string.Join(',', Sort(testData))}");
        }
    }
}
