using System;
using System.Collections.Generic;
using System.Linq;

class FootballStandings
{
    static void Main()
    {
        string key = Console.ReadLine();

        Dictionary<string, int> scoresByTeams = new Dictionary<string, int>();
        Dictionary<string, int> goalsByTeams = new Dictionary<string, int>();

        string input = Console.ReadLine();
        while (input != "final")
        {
            FillTheDictionaries(key, input, scoresByTeams, goalsByTeams);
            input = Console.ReadLine();
        }

        PrintResult(scoresByTeams, goalsByTeams);
    }

    public static void FillTheDictionaries(string key, string input, 
        Dictionary<string, int> scoresByTeams, Dictionary<string, int> goalsByTeams)
    {
        int team1StartIndex = input.IndexOf(key) + key.Length;
        int team1EndIndex = input.IndexOf(key, team1StartIndex) - 1;
        int team1Length = team1EndIndex - team1StartIndex + 1;
        string team1Reversed = input.Substring(team1StartIndex, team1Length).ToUpper();

        string team1 = new string(team1Reversed.Reverse().ToArray());

        int team2StartIndex = input.IndexOf(key, team1EndIndex + key.Length) + key.Length;
        int team2EndIndex = input.IndexOf(key, team2StartIndex) - 1;
        int team2Length = team2EndIndex - team2StartIndex + 1;
        string team2Reversed = input.Substring(team2StartIndex, team2Length).ToUpper();

        string team2 = new string(team2Reversed.Reverse().ToArray());

        int teamsResultStartIndex = input.IndexOf(" ", team2EndIndex + key.Length) + 1;
        int[] teamResult = input.Substring(teamsResultStartIndex).Split(':')
            .Select(int.Parse).ToArray();

        if (!scoresByTeams.ContainsKey(team1))
        {
            scoresByTeams[team1] = 0;
        }

        if (!scoresByTeams.ContainsKey(team2))
        {
            scoresByTeams[team2] = 0;
        }

        if (teamResult[0] == teamResult[1])
        {
            scoresByTeams[team1] += 1;
            scoresByTeams[team2] += 1;
        }
        else if (teamResult[0] > teamResult[1])
        {
            scoresByTeams[team1] += 3;
        }
        else
        {
            scoresByTeams[team2] += 3;
        }

        if (!goalsByTeams.ContainsKey(team1))
        {
            goalsByTeams[team1] = 0;
        }

        if (!goalsByTeams.ContainsKey(team2))
        {
            goalsByTeams[team2] = 0;
        }

        goalsByTeams[team1] += teamResult[0];
        goalsByTeams[team2] += teamResult[1];
    }

    public static void PrintResult(Dictionary<string, int> scoresByTeams, 
        Dictionary<string, int> goalsByTeams)
    {
        scoresByTeams = scoresByTeams.OrderByDescending(s => s.Value)
            .ThenBy(s => s.Key).ToDictionary(s => s.Key, s => s.Value);

        goalsByTeams = goalsByTeams.OrderByDescending(g => g.Value)
            .ThenBy(g => g.Key).Take(3).ToDictionary(g => g.Key, g => g.Value);

        int counter = 1;

        Console.WriteLine("League standings:");

        foreach (var item in scoresByTeams)
        {
            Console.WriteLine($"{counter}. {item.Key} {item.Value}");
            counter++;
        }

        Console.WriteLine("Top 3 scored goals:");

        foreach (var item in goalsByTeams)
        {
            Console.WriteLine($"- {item.Key} -> {item.Value}");
            counter++;
        }
    }
}

