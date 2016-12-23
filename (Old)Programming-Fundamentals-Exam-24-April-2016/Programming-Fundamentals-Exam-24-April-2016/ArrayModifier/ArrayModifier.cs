using System;
using System.Linq;

class ArrayModifier
{
    static void Main()
    {
        long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();

        string input = Console.ReadLine();
        while (!input.Equals("end"))
        {
            string[] commands = input.Split();

            if (commands[0].Equals("swap"))
            {
                SwapNumbers(numbers, commands);
            }
            else if (commands[0].Equals("multiply"))
            {
                MultiplyNumbers(numbers, commands);
            }
            else
            {
                numbers = numbers.Select(n => n - 1).ToArray();
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(string.Join(", ", numbers));
    }

    private static void SwapNumbers(long[] numbers, string[] commands)
    {
        int position1 = int.Parse(commands[1]);
        int position2 = int.Parse(commands[2]);
        long numAtPosition1 = numbers[position1];
        long numAtPosition2 = numbers[position2];

        numbers[position1] = numAtPosition2;
        numbers[position2] = numAtPosition1;
    }

    private static void MultiplyNumbers(long[] numbers, string[] commands)
    {
        int position1 = int.Parse(commands[1]);
        int position2 = int.Parse(commands[2]);
        long numAtPosition1 = numbers[position1];
        long numAtPosition2 = numbers[position2];

        numbers[position1] = numAtPosition1 * numAtPosition2;
    }
}

