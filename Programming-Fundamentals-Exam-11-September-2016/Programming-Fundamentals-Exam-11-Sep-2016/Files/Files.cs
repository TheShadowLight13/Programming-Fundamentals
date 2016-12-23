using System;
using System.Collections.Generic;
using System.Linq;

class Files
{
    static void Main()
    {
        int fileCount = int.Parse(Console.ReadLine());
        List<string> files = ReadFiles(fileCount);

        string[] queryParams = Console.ReadLine().Split().Where(w => w != "in").ToArray();

        PrintResult(ExecuteQuery(files, queryParams[0], queryParams[1]));
       
    }

    public static void PrintResult(Dictionary<string, int> filteredFiles)
    {
        if (filteredFiles.Count != 0)
        {
            foreach (var file in filteredFiles)
            {
                Console.WriteLine($"{file.Key} - {file.Value} KB");
            }
        }
        else
        {
            Console.WriteLine("No");
        }
        
    }

    public static Dictionary<string, int> ExecuteQuery(List<string> files, 
        string extension, string rootFolder)
    {
        List<string> requirementFiles = files
            .Where(file => file.Split('\\')[0] == rootFolder && file.Split('\\').Last().
            Contains("." + extension)).ToList();

        Dictionary<string, int> fileNameBySize = new Dictionary<string, int>();

        for (int i = 0; i < requirementFiles.Count; i++)
        {
            string fileName = requirementFiles[i].Split('\\').Last().Split(';')[0];
            string fileSize = requirementFiles[i].Split('\\').Last().Split(';')[1];

            if (!fileNameBySize.ContainsKey(fileName))
            {
                fileNameBySize[fileName] = 0;
                fileNameBySize[fileName] = int.Parse(fileSize);

            }
            else
            {
                fileNameBySize[fileName] = int.Parse(fileSize);
            }
        }
        fileNameBySize = fileNameBySize.OrderByDescending(f => f.Value)
            .ThenBy(f => f.Key).ToDictionary(f => f.Key, f => f.Value);

        return fileNameBySize;
    }

    public static List<string> ReadFiles(int fileCount)
    {
        List<string> files = new List<string>();

        for (int i = 0; i < fileCount; i++)
        {
            files.Add(Console.ReadLine());
        }
        return files;
    }
}

