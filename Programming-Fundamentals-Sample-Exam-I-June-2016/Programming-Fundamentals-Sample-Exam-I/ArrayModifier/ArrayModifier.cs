using System;
using System.Collections.Generic;
using System.Linq;

class ArrayModifier
{
    static void Main()
    {
        List<long> numbersList = Console.ReadLine().Split(' ').Select(long.Parse).ToList();

        string input = Console.ReadLine();
        while (input != "end")
        {
            string command = input.Split(' ')[0];
            if (command == "swap")
            {
                int index1 = int.Parse(input.Split(' ')[1]);
                int index2 = int.Parse(input.Split(' ')[2]);
                SwapNumbers(numbersList, index1, index2);
            }
            else if (command == "multiply")
            {
                int index1 = int.Parse(input.Split(' ')[1]);
                int index2 = int.Parse(input.Split(' ')[2]);
                MultiplyNumbers(numbersList, index1, index2);
            }
            else
            {
                numbersList = DecreaseNumbers(numbersList);
            }

            input = Console.ReadLine();
        }

        PrintNumbersList(numbersList);
    }

    private static void SwapNumbers(List<long> numbersList, int index1, int index2)
    {
        long numberOnIndex1 = numbersList[index1];
        long numberOnIndex2 = numbersList[index2];

        numbersList[index1] = numberOnIndex2;
        numbersList[index2] = numberOnIndex1;
    }

    private static void MultiplyNumbers(List<long> numbersList, int index1, int index2)
    {
        long numberOnIndex1 = numbersList[index1];
        long numberOnIndex2 = numbersList[index2];

        numbersList[index1] = numberOnIndex1 * numberOnIndex2;
    }

    private static List<long> DecreaseNumbers(List<long> numbersList)
    {
        numbersList = numbersList.Select(n => n - 1).ToList();
        return numbersList;
    }

    private static void PrintNumbersList(List<long> numberList)
    {
        Console.WriteLine(string.Join(", ", numberList));
    }
}

