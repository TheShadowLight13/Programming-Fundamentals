using System;
using System.Linq;

class Numbers
{
    static void Main()
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        double averageSumNums = nums.Average();

        int[] finalNums = nums.Where(n => n > averageSumNums).OrderByDescending(n => n)
            .Take(5).ToArray();

        if (finalNums.Length != 0)
        {
            Console.WriteLine(string.Join(" ", finalNums));
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}

