using System;
using System.Globalization;
using System.Numerics;

class SoftuniCoffeeOrders
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        decimal totalCoffeePrice = 0;

        for (int i = 0; i < n; i++)
        {
            decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
            DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
            long capsulesCount = long.Parse(Console.ReadLine());

            int daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
            decimal currentCoffeePrice = (daysInMonth * capsulesCount) * pricePerCapsule;
            Console.WriteLine($"The price for the coffee is: ${currentCoffeePrice:F2}");

            totalCoffeePrice += currentCoffeePrice;
        }

        Console.WriteLine($"Total: ${totalCoffeePrice:F2}");
    }
}

