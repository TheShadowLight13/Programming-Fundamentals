using System;

class SweetDessert
{
    static void Main()
    {
        decimal amountCash = decimal.Parse(Console.ReadLine());
        long guests = long.Parse(Console.ReadLine());
        decimal bananaPrice = decimal.Parse(Console.ReadLine());
        decimal eggPrice = decimal.Parse(Console.ReadLine());
        decimal berriesPrice = decimal.Parse(Console.ReadLine());

        int portionsSet = (int)Math.Ceiling(guests/6.0);
        decimal spendedMoney = (portionsSet*(2*bananaPrice)) + (portionsSet*(4*eggPrice)) +
                               (portionsSet*(0.2M*berriesPrice));

        if (spendedMoney <= amountCash)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {spendedMoney:F2}lv.");
        }
        else
        {
            decimal neededMoney = spendedMoney - amountCash;
            Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.",
                neededMoney);
        }
    }
}

