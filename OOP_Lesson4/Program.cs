using System;

namespace OOP_Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            var building = new Building();
            building.Haight = 14;
            building.NumberOfEntrances = 3;
            building.NumberOfFlats = 36;
            building.NumberOfFloors = 4;

            Console.WriteLine($"HaightOfFloor:" +
                $" {Building.CountHaightOfFloor(building.Haight, building.NumberOfFloors)}");
            Console.WriteLine($"FlatsInEntrance:" +
                $"{Building.CountFlatsInEntrance(building.NumberOfFlats, building.NumberOfEntrances)}");
            Console.WriteLine($"FlatsOnTheFloor:" +
                $"{Building.CountFlatsOnTheFloor(building.NumberOfFlats, building.NumberOfEntrances, building.NumberOfFloors)}");

            Console.WriteLine($"Номер первого здания: {building.Number}");
            var building2 = new Building();
            Console.WriteLine($"Номер второго здания: {building2.Number}");

            Console.ReadKey();

        }
    }
}
