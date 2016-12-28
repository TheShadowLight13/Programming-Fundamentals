using System;
using System.Linq;
using System.Net;

class Ladybugs
{
    static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());
        long[] initialIndexes = Console.ReadLine().Split().Select(long.Parse).ToArray();

        long[] field = new long[fieldSize];

        // Set initially indexes
        for (int i = 0; i < initialIndexes.Length; i++)
        {
            long initialIndex = initialIndexes[i];

            if (initialIndex >= 0 && initialIndex < fieldSize)
            {
                field[initialIndex] = 1;
            }
        }

        string input = Console.ReadLine();

        while (!input.Equals("end"))
        {
            string[] commands = input.Split();

            long index = long.Parse(commands.First());
            string direction = commands[1];
            long flyLength = long.Parse(commands.Last());

            if (index >= 0 && index < fieldSize)
            {
                PerformFlying(field, index, direction, flyLength);
            }

            input = Console.ReadLine();
        }

        // Print result
        Console.WriteLine(string.Join(" ", field));
    }

    private static void PerformFlying(long[] field, long index, string direction, long flyLength)
    {

        if (field[index] == 0)
        {
            return;
        }

        long dir = direction.Equals("left") ? (-1 * flyLength) : flyLength;
        field[index] = 0;

        while (true)
        {

            long nextIndex = index + dir;
            index = nextIndex;

            if (index >= 0 && index < field.Length)
            {
                if (field[index] == 0)
                {
                    field[index] = 1;
                    break;
                }
            }
            else
            {
                break;
            }
        }
    }
}

