using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class RageQuit
{
    static void Main()
    {
        string input = Console.ReadLine();

        string pattern = @"(\D+)(\d+)";
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(input);

        StringBuilder resultStr = new StringBuilder();

        foreach (Match match in matches)
        {
            string str = match.Groups[1].Value.ToUpper();
            int repeatCount = int.Parse(match.Groups[2].Value);
            resultStr.Append(GetResultStr(str, repeatCount));
        }

        int uniqueSymbolsCount = resultStr.ToString().Distinct().Count();

        Console.WriteLine("Unique symbols used: {0}", uniqueSymbolsCount);
        Console.WriteLine(resultStr);
    }

    private static string GetResultStr(string str, int repeatCount)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < repeatCount; i++)
        {
            sb.Append(str);
        }

        return sb.ToString();
    }
}