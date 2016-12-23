using System;
using System.Globalization;

class SoftuniCoffeeOrders
{
    static void Main()
    {
        int ordersCount = int.Parse(Console.ReadLine());

        decimal totalCoffeePrice = 0;

        for (int i = 0; i < ordersCount; i++)
        {
            decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
            DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy",
                CultureInfo.InvariantCulture);
            uint capsulesCount = uint.Parse(Console.ReadLine());

            decimal coffeePrice = ((DateTime.DaysInMonth(orderDate.Year, orderDate.Month) 
                * capsulesCount) * pricePerCapsule);

            Console.WriteLine($"The price for the coffee is: ${coffeePrice:F2}");
            totalCoffeePrice += coffeePrice;
        }

        Console.WriteLine($"Total: ${totalCoffeePrice:F2}");
    }
}

