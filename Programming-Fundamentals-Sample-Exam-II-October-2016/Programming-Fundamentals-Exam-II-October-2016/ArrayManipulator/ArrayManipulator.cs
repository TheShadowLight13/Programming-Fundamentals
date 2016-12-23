using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

class ArrayManipulator
{
    static void Main()
    {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

        string line = Console.ReadLine();
        while (!line.Equals("end"))
        {
            string[] commands = line.Split();

            switch (commands[0])
            {
                case "exchange":
                    int index = int.Parse(commands[1]);
                    if (index >= 0 && index < numbers.Length)
                    {
                        index += 1;
                        numbers = Exchange(numbers, index);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index");
                    }
                    break;

                case "max":
                case "min":
                    Console.WriteLine(GetIndex(numbers, commands[0], commands[1]));
                    break;
                case "first":
                case "last" :
                    Console.WriteLine(GetSequence(numbers, int.Parse(commands[1]), 
                        commands[0], commands[2]));
                    break;
            }

            line = Console.ReadLine();
        }

        Console.WriteLine("[{0}]", string.Join(", ", numbers));
    }

    private static string GetSequence(int[] numbers, int count, string type, string parity)
    {
        if (count > numbers.Length)
        {
            return "Invalid count";
        }

        int remainder = parity == "odd" ? 1 : 0;
        int[] filtered = numbers.Where(n => n % 2 == remainder).ToArray();

        return type == "first"
            ? "[" + string.Join(", ", filtered.Take(count)) + "]"
            : "[" + string.Join(", ", filtered.Reverse().Take(count).Reverse()) + "]";
    }

    private static int[] Exchange(int[] numbers, int index)
    {
        return numbers.Skip(index).Concat(numbers.Take(index)).ToArray();
    }

    static string GetIndex(int[] numbers, string type, string parity)
    {
        int remainder = parity == "odd" ? 1 : 0;
        int[] filtered = numbers.Where(n => n % 2 == remainder).ToArray();

        if (!filtered.Any())
        {
            return "No matches";
        }

        return type == "min"
            ? Array.LastIndexOf(numbers, filtered.Min()).ToString()
            : Array.LastIndexOf(numbers, filtered.Max()).ToString();
    }
}

