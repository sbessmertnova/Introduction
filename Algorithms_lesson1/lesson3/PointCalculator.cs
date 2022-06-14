using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_lesson1.lesson3
{
    public class PointCalculator
    {
        private const int maxCoord = 100;
        public static double GetLengthBetweenClassPoints(PointClassDouble point1, PointClassDouble point2)
        {
            var xDif = point2.X - point1.X;
            var yDif = point2.Y - point1.Y;
            return Math.Sqrt(Math.Pow(xDif, 2) + Math.Pow(yDif, 2));
        }
        public static double GetLengthBetweenStructPoints(PointStructDouble point1, PointStructDouble point2)
        {
            var xDif = point2.X - point1.X;
            var yDif = point2.Y - point1.Y;
            return Math.Sqrt(Math.Pow(xDif, 2) + Math.Pow(yDif, 2));
        }

        public static
            ((PointClassDouble, PointClassDouble)[],
             (PointStructDouble, PointStructDouble)[])
            GeneratePoints(int size)
        {
            var rnd = new Random();
            var classResult = new (PointClassDouble, PointClassDouble)[size];
            var structResult = new (PointStructDouble, PointStructDouble)[size];

            classResult = classResult.Select(emptyElement => (GetClassPoint(rnd), GetClassPoint(rnd))).ToArray();
            structResult = classResult.Select(emptyElement => (GetStructPoint(rnd), GetStructPoint(rnd))).ToArray();
            return (classResult, structResult);
        }
        private static PointClassDouble GetClassPoint(Random random) =>
            new PointClassDouble
            {
                X = random.Next(maxCoord),
                Y = random.Next(maxCoord)
            };
        private static PointStructDouble GetStructPoint(Random random) =>
            new PointStructDouble
            {
                X = random.Next(maxCoord),
                Y = random.Next(maxCoord)
            };
        public static PointClassDouble[] GenerateArrayClassPoint(int size)
        {
            PointClassDouble[] array = new PointClassDouble[size];
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i].X = rand.Next();
            rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i].Y = rand.Next();
            return array;
        }
        public static PointStructDouble[] GenerateArrayStructPoint(int size)
        {
            PointStructDouble[] array = new PointStructDouble[size];
            var rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i].X = rand.Next();
            rand = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i].Y = rand.Next();
            return array;
        }
    }
}
