using System;
using System.Diagnostics;
using System.Linq;

namespace Algorithms_lesson1.lesson3
{
    public class PointsLengthTests
    {
        public static void Tests()
        {
            TestLength(1000000);
            TestLength(2000000);
            TestLength(5000000);
        }
        public static void TestLength(int pointAmount)
        {
            var testElements = PointCalculator.GeneratePoints(pointAmount);
            var sw = new Stopwatch();
            sw.Start();
            var classResults = testElements.Item1.Select(point =>
            PointCalculator.GetLengthBetweenClassPoints(point.Item1, point.Item2)).ToArray();
            sw.Stop();
            var classtime = sw.Elapsed;
            sw.Reset();
            sw.Start();
            var structResults = testElements.Item2.Select(point =>
            PointCalculator.GetLengthBetweenStructPoints(point.Item1, point.Item2)).ToArray();
            sw.Stop();
            var structTime = sw.Elapsed;
            Console.WriteLine($"{pointAmount}|{classtime}|{structTime}|{classtime / structTime}");
        }
    }
}
