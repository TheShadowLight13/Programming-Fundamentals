using System;

class CharityMarathon
{
    static void Main()
    {
        int marathonDays = int.Parse(Console.ReadLine());
        long runnersCount = long.Parse(Console.ReadLine());
        int averageLaps = int.Parse(Console.ReadLine());
        long trackLength = long.Parse(Console.ReadLine());
        int trackCapacity = int.Parse(Console.ReadLine());
        decimal moneyPerKm = decimal.Parse(Console.ReadLine());

        long maxRunners = trackCapacity*marathonDays;
        long participatedRunners = runnersCount > maxRunners ? maxRunners : runnersCount;

        long totalKms = (participatedRunners*averageLaps*trackLength) / 1000;
        decimal raisedMoney = totalKms*moneyPerKm;

        Console.WriteLine("Money raised: {0:F2}", raisedMoney);

    }
}

