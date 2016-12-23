using System;
using System.Collections.Generic;
using System.Linq;

class VehiclePark
{
    static void Main()
    {
        
        List<string> vehicles = Console.ReadLine().Split().ToList();

        int vehiclesSold = 0;

        string input = Console.ReadLine();
        while (!input.Equals("End of customers!"))
        {
            string[] commands = input.ToLower().Split();
            char vehicleType = commands.First()[0];
            int seatsCount = int.Parse(commands[2]);

            string vehicle = vehicleType + ""+ seatsCount;
            if (vehicles.Contains(vehicle))
            {
                int soldPrice = vehicleType*seatsCount;
                Console.WriteLine($"Yes, sold for {soldPrice}$");
                vehiclesSold++;
                vehicles.Remove(vehicle);
            }
            else
            {
                Console.WriteLine("No");
            }

            input = Console.ReadLine();
        }

        PrintLeftVehicles(vehicles, vehiclesSold);
    }

    private static void PrintLeftVehicles(List<string> vehicles, int vehiclesSold)
    {
        Console.WriteLine("Vehicles left: {0}", string.Join(", ", vehicles));
        Console.WriteLine($"Vehicles sold: {vehiclesSold}");
    }
}

