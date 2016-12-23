using System;

class SweetDessert
{
    static void Main()
    {
        double cash = double.Parse(Console.ReadLine());
        int guests = int.Parse(Console.ReadLine());
        double bananaPrice = double.Parse(Console.ReadLine());
        double eggPrice = double.Parse(Console.ReadLine());
        double berriesPrice = double.Parse(Console.ReadLine());

        int portions = (int)(Math.Ceiling(guests / 6.0));
        double spendedMoney =
            (portions*(2*bananaPrice)) + (portions*(4*eggPrice)) + (portions*(0.2*berriesPrice));

        if (spendedMoney <= cash)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {spendedMoney:F2}lv.");
        }
        else
        {
            double neededMoney = spendedMoney - cash;
            Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.",
                neededMoney);
        }
    }
}

