using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class CommandInterpreter
{
    static void Main()
    {
        string spacePattern = @"\s+";
        Regex regEx = new Regex(spacePattern);

        List<string> input = regEx.Split(Console.ReadLine()).Where(x => x != "").ToList();
        string commands = Console.ReadLine();

        while (!commands.Equals("end"))
        {
            string[] line = commands.Split();
            int start = 0;
            int count = 0;

            switch (line[0])
            {
                case "reverse":
                    start = int.Parse(line[2]);
                    count = int.Parse(line[4]);

                    if (start < 0 || count < 0 || start >= input.Count || (start + count) > input.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    ReverseElements(input, start, count);
                    break;

                case "sort":
                    start = int.Parse(line[2]);
                    count = int.Parse(line[4]);

                    if (start < 0 || count < 0 || start >= input.Count || (start + count) > input.Count)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    SortElements(input, start, count);
                    break;

                case "rollLeft":
                    count = int.Parse(line[1]);

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    RollLeft(input, count);
                    break;

                case "rollRight":
                    count = int.Parse(line[1]);

                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                        break;
                    }

                    RollRight(input, count);
                    break;
            }

            commands = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", string.Join(", ", input));

    }

    private static void RollRight(List<string> input, int count)
    {
        for (long i = 0; i < (count % input.Count); i++)
        {
            string lastElement = input.Last();
            input.RemoveAt(input.Count - 1);
            input.Insert(0, lastElement);
        }
    }

    private static void RollLeft(List<string> input, int count)
    {
        for (int i = 0; i < (count % input.Count); i++)
        {
            string firstElement = input[0];

            input.RemoveAt(0);
            input.Add(firstElement);
        }
    }

    private static void SortElements(List<string> input, int start, int count)
    {
        List<string> sortedElements = input.Skip(start).Take(count).OrderBy(x => x).ToList();
        input.RemoveRange(start, count);
        input.InsertRange(start, sortedElements);
    }

    private static void ReverseElements(List<string> input, int start, int count)
    {
        List<string> reversedElements = input.Skip(start).Take(count).Reverse().ToList();
        input.RemoveRange(start, count);
        input.InsertRange(start, reversedElements);
    }
}

