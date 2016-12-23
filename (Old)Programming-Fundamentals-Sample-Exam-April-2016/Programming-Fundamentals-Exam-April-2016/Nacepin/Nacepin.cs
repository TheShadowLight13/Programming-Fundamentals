using System;
using System.Collections.Generic;
using System.Linq;

class Nacepin
{
    static void Main()
    {
        Dictionary<string, decimal> priceByCountry = new Dictionary<string, decimal>();

        decimal priceInUSD = decimal.Parse(Console.ReadLine());
        decimal usBoxWeight = decimal.Parse(Console.ReadLine());

        priceByCountry["US"] = 0;
        priceByCountry["US"] = (priceInUSD/0.58M)/usBoxWeight;

        decimal priceInGBP = decimal.Parse(Console.ReadLine());
        decimal ukBoxWeight = decimal.Parse(Console.ReadLine());

        priceByCountry["UK"] = 0;
        priceByCountry["UK"] = (priceInGBP/0.41M)/ukBoxWeight;


        decimal priceInCNY = decimal.Parse(Console.ReadLine());
        decimal chineseBoxWeight = decimal.Parse(Console.ReadLine());

        priceByCountry["Chinese"] = 0;
        priceByCountry["Chinese"] = (priceInCNY*0.27M)/chineseBoxWeight;

        var lowestPrice = priceByCountry.OrderBy(x => x.Value).First();
        Console.WriteLine($"{lowestPrice.Key} store. {lowestPrice.Value:F2} lv/kg");

        var biggestPrice = priceByCountry.OrderByDescending(x => x.Value).First();
        decimal diff = biggestPrice.Value - lowestPrice.Value;
        Console.WriteLine($"Difference {diff:F2} lv/kg");
    }
}

