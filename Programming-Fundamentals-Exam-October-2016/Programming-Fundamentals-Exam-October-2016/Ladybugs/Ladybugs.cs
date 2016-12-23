using System;
using System.Linq;

class Ladybugs
{
    static void Main()
    {
        int fieldSize = int.Parse(Console.ReadLine());
        long[] field = new long[fieldSize];
        long[] ladyBugsOnIndexes = Console.ReadLine().Split().Select(long.Parse).ToArray();

        for (int i = 0; i < ladyBugsOnIndexes.Length; i++)
        {
            long currentIndex = ladyBugsOnIndexes[i];

            if (currentIndex >= 0 && currentIndex < field.Length)
            {
                field[currentIndex] = 1;
            }
        }

        string input = Console.ReadLine();
        while (!input.Equals("end"))
        {
            string[] commands = input.Split();

            long index = long.Parse(commands[0]);
            string direction = commands[1];
            long flyLen = long.Parse(commands[2]);

            if (index >= 0 && index < field.Length)
            {
                if (field[index] == 1)
                {
                    if (direction.Equals("left"))
                    {
                        long currentIndex = index - flyLen;
                        if (currentIndex >= 0 && currentIndex < field.Length)
                        {
                            if (field[currentIndex] == 0)
                            {
                                field[index] = 0;
                                field[currentIndex] = 1;
                            }
                            else
                            {
                                field[index] = 0;
                                FlyInField(field, currentIndex, flyLen, direction);
                            }
                        }
                        else
                        {
                            field[index] = 0;
                        }
                    }
                    else if (direction.Equals("right"))
                    {
                        long currentIndex = index + flyLen;
                        if (currentIndex >= 0 && currentIndex < field.Length)
                        {
                            if (field[currentIndex] == 0)
                            {
                                field[index] = 0;
                                field[currentIndex] = 1;
                            }
                            else
                            {
                                field[index] = 0;
                                FlyInField(field, currentIndex, flyLen, direction);
                            }
                        }
                        else
                        {
                            field[index] = 0;
                        }
                    }
                }            
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(string.Join(" ", field));
    }

    private static void FlyInField(long[] field, long currentIndex, long flyLen, string direction)
    {
        while (true)
        {
            if (direction.Equals("left"))
            {
                currentIndex -= flyLen;
                if (currentIndex >= 0 && currentIndex < field.Length)
                {
                    if (field[currentIndex] == 0)
                    {
                        field[currentIndex] = 1;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            else
            {
                currentIndex += flyLen;
                if (currentIndex >= 0 && currentIndex < field.Length)
                {
                    if (field[currentIndex] == 0)
                    {
                        field[currentIndex] = 1;
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
}

