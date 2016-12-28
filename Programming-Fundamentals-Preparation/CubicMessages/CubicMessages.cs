using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class CubicMessages
{
    static void Main()
    {
        string input = Console.ReadLine();

        while (!input.Equals("Over!"))
        {
            int count = int.Parse(Console.ReadLine());
            string pattern = @"(^[0-9]+)([a-zA-Z]{" + count + @"})([^a-zA-Z]*)$";
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                string message = match.Groups[2].Value;
                List<int> indexes = GetIndexes(match);
                Console.Write(message + " == ");

                for (int i = 0; i < indexes.Count; i++)
                {
                    int index = indexes[i];

                    if (index >= 0 && index < message.Length)
                    {
                        Console.Write(message[index]);
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();
            }
            input = Console.ReadLine();
        }
    }

    private static List<int> GetIndexes(Match match)
    {
        List<int> indexes = new List<int>();
        string left = match.Groups[1].Value;

        for (int i = 0; i < left.Length; i++)
        {
            if (char.IsDigit(left[i]))
            {
                indexes.Add(int.Parse(left[i].ToString()));
            }
        }

        string right = match.Groups[3].Value;

        for (int i = 0; i < right.Length; i++)
        {
            if (char.IsDigit(right[i]))
            {
                indexes.Add(int.Parse(right[i].ToString()));
            }
        }

        return indexes;
    }
}

