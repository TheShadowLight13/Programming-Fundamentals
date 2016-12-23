using System;
using System.Diagnostics.Eventing.Reader;

class CharityMarathon
{
    static void Main()
    {
        int marathonDays = int.Parse(Console.ReadLine());
        long runnersCount = int.Parse(Console.ReadLine());
        int averageLaps = int.Parse(Console.ReadLine());
        long trackLen = long.Parse(Console.ReadLine());
        int trackCapacity = int.Parse(Console.ReadLine());
        decimal moneyPerKm = decimal.Parse(Console.ReadLine());

        long maximumRunnersOnTrack = marathonDays*trackCapacity;
        long runnersOnTrack = 0;

        if (runnersCount <= maximumRunnersOnTrack)
        {
            runnersOnTrack = runnersCount;
        }
        else
        {
            runnersOnTrack = maximumRunnersOnTrack;
        }
        

        long totalMeters = runnersOnTrack*averageLaps*trackLen;
        long totalKms = totalMeters/1000;

        decimal moneyForMarathon = totalKms*moneyPerKm;
        Console.WriteLine("Money raised: {0:F2}", moneyForMarathon);
    }
}

