using System;
using System.Collections.Generic;
using System.Linq;

class HogwartsSorting
{
    static void Main()
    {
        Dictionary<string, int> studentsCountByHouseName = new Dictionary<string, int>();
        studentsCountByHouseName["Gryffindor"] = 0;
        studentsCountByHouseName["Slytherin"] = 0;
        studentsCountByHouseName["Ravenclaw"] = 0;
        studentsCountByHouseName["Hufflepuff"] = 0;

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string studentName = Console.ReadLine();
            string initialLetters = new string(studentName.Split().Select(x => x[0]).ToArray());
            int lettersSum = studentName.ToCharArray().Where(x => x != ' ').Sum(x => x);

            int remainder = lettersSum%4;
            switch (remainder)
            {
                case 0:
                    studentsCountByHouseName["Gryffindor"]++;
                    Console.WriteLine($"Gryffindor {lettersSum}{initialLetters}"); break;
                case 1:
                    studentsCountByHouseName["Slytherin"]++;
                    Console.WriteLine($"Slytherin {lettersSum}{initialLetters}"); break;
                case 2:
                    studentsCountByHouseName["Ravenclaw"]++;
                    Console.WriteLine($"Ravenclaw {lettersSum}{initialLetters}"); break;
                case 3:
                    studentsCountByHouseName["Hufflepuff"]++;
                    Console.WriteLine($"Hufflepuff {lettersSum}{initialLetters}"); break;
            }
        }

        Console.WriteLine();
        PrintStudentsCountByHouseName(studentsCountByHouseName);
    }

    private static void PrintStudentsCountByHouseName(Dictionary<string, int> studentsCountByHouseName)
    {
        foreach (var student in studentsCountByHouseName)
        {
            Console.WriteLine($"{student.Key}: {student.Value}");
        }
    }
}

