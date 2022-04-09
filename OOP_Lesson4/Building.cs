using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lesson4
{
    public class Building
    {
        private int number;
        private double haight;
        private int numberOfFloors;
        private int numberOfFlats;
        private int numberOfEntrances;
        
        public int Number { get => number;
            set
            {
                number = value;
            }
        }
        public double Haight { get => haight;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Значение не может быть меньше нуля или равным нулю");
                }
                haight = value;
            }
        }
        public int NumberOfFloors { get => numberOfFloors;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Значение не может быть меньше нуля или равным нулю");
                }
                numberOfFloors = value;
            }
        }
        public int NumberOfFlats { get => numberOfFlats;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Значение не может быть меньше нуля или равным нулю");
                }
                numberOfFlats = value;
            }
        }
        public int NumberOfEntrances { get => numberOfEntrances;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Значение не может быть меньше нуля или равным нулю");
                }
                numberOfEntrances = value;
            }
        }
        static int generatedBuildingNumber;

        public Building()
        {
            IncreaseNumber();
            Number = GeneratedBuildingNumber;
        }

        public static int GeneratedBuildingNumber
        {
            get => generatedBuildingNumber;
            set
            {
                generatedBuildingNumber = value;
            }
        }
        public static void IncreaseNumber()
        {
            GeneratedBuildingNumber++;
        }

        public static double CountHaightOfFloor(double haight, int numberOfFloors)
        {
            return haight / numberOfFloors;
        }
        public static int CountFlatsInEntrance(int numberOfFlats, int numberOfEntrances)
        {
            if (numberOfFlats< numberOfEntrances)
            {
                throw new ArgumentException("Количество квартир не может быть меньше количества подъездов");
            }
            if (numberOfFlats % numberOfEntrances!=0)
            {
                throw new ArgumentException("В подъездах не может быть разного количества квартир. " +
                    "Проверьте правильность введенных данных");
            }
            return numberOfFlats / numberOfEntrances;
        }
        public static int CountFlatsOnTheFloor(int numberOfFlats, int numberOfEntrances, int numberOfFloors)
        {
            var flatsInEntrance = CountFlatsInEntrance(numberOfFlats, numberOfEntrances);
            if (flatsInEntrance < numberOfFloors)
            {
                throw new ArgumentException("Количество квартир не может быть меньше количества этажей");
            }
            if (flatsInEntrance % numberOfFloors != 0)
            {
                throw new ArgumentException("На этажах не может быть разного количества квартир. " +
                    "Проверьте правильность введенных данных");
            }
            return flatsInEntrance / numberOfFloors;
        }
    }
}
