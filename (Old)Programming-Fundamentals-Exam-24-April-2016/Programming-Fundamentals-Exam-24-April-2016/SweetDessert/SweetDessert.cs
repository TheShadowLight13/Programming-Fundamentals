using System;

class SweetDessert
{
    static void Main()
    {
        decimal cashAmount = decimal.Parse(Console.ReadLine());
        int guestsCount = int.Parse(Console.ReadLine());
        decimal bananaPrice = decimal.Parse(Console.ReadLine());
        decimal eggPrice = decimal.Parse(Console.ReadLine());
        decimal berriesPrice = decimal.Parse(Console.ReadLine());

        int portionsSetCount = (int)Math.Ceiling(guestsCount/6.0);
        decimal spendedMoney = (portionsSetCount*(2*bananaPrice)) + (portionsSetCount*(4*eggPrice)) +
                               (portionsSetCount*(0.2M*berriesPrice));

        if (spendedMoney <= cashAmount)
        {
            Console.WriteLine($"Ivancho has enough money - it would cost {spendedMoney:F2}lv.");
        }
        else
        {
            decimal neededMoney = spendedMoney - cashAmount;
            Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.",
            neededMoney);
        }
    }
}

