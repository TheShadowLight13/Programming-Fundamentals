using System;
using System.Linq;

class GrumpyCat
{
    static void Main()
    {
        int[] priceRatings = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int entryPoint = int.Parse(Console.ReadLine());
        string itemsType = Console.ReadLine();
        string priceRatingsType = Console.ReadLine();

        int priceRatingEntryPoint = priceRatings[entryPoint];

        long leftSum = 0;
        long rightSum = 0;

        // Get left sum
        for (int i = entryPoint - 1; i >= 0; i--)
        {
            int priceRating = priceRatings[i];
            leftSum += GetSum(priceRating, priceRatingEntryPoint, itemsType, priceRatingsType);
        }

        // Get right sum
        for (int i = entryPoint + 1; i < priceRatings.Length; i++)
        {
            int priceRating = priceRatings[i];
            rightSum += GetSum(priceRating, priceRatingEntryPoint, itemsType, priceRatingsType);
        }

        if (leftSum >= rightSum)
        {
            Console.WriteLine($"Left - {leftSum}");
        }
        else
        {
            Console.WriteLine($"Right - {rightSum}");
        }
    }

    public static long GetSum(int priceRating, int priceRatingEntryPoint,
        string itemsType, string priceRatingsType)
    {
        long totalSum = 0;

        if (itemsType == "cheap")
        {
            switch (priceRatingsType)
            {
                case "positive":
                    if (priceRating < priceRatingEntryPoint && priceRating > 0)
                    {
                        totalSum += priceRating;
                    }
                    break;
                case "negative":
                    if (priceRating < priceRatingEntryPoint && priceRating < 0)
                    {
                        totalSum += priceRating;
                    }
                    break;
                case "all":
                    if (priceRating < priceRatingEntryPoint)
                    {
                        totalSum += priceRating;
                    }
                    break;
            }
        }
        else if (itemsType == "expensive")
        {
            switch (priceRatingsType)
            {
                case "positive":
                    if (priceRating >= priceRatingEntryPoint && priceRating > 0)
                    {
                        totalSum += priceRating;
                    }
                    break;
                case "negative":
                    if (priceRating >= priceRatingEntryPoint && priceRating < 0)
                    {
                        totalSum += priceRating;
                    }
                    break;
                case "all":
                    if (priceRating >= priceRatingEntryPoint)
                    {
                        totalSum += priceRating;
                    }
                    break;
            }
        }
        return totalSum;
    }
}

