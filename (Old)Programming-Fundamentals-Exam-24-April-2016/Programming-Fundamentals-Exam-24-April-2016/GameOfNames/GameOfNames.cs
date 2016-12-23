using System;
using System.Collections.Generic;
using System.Linq;

class GameOfNames
{
    static void Main()
    {
        Dictionary<string, int> scoresByPlayerName = new Dictionary<string, int>();

        int playersCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < playersCount; i++)
        {
            string playerName = Console.ReadLine();
            int initialPlayerScores = int.Parse(Console.ReadLine());

            int totalPlayerScores = GetTotalPlayerScores(playerName, initialPlayerScores);

            if (!scoresByPlayerName.ContainsKey(playerName))
            {
                scoresByPlayerName[playerName] = 0;
            }

            scoresByPlayerName[playerName] = totalPlayerScores;
        }

        scoresByPlayerName = scoresByPlayerName.OrderByDescending(x => x.Value).Take(1)
            .ToDictionary(x => x.Key, x => x.Value);

        string winnerName = scoresByPlayerName.First().Key;
        int winnerPoints = scoresByPlayerName.First().Value;

        Console.WriteLine($"The winner is {winnerName} - {winnerPoints} points");
    }

    private static int GetTotalPlayerScores(string playerName, int initialPlayerScores)
    {
        int totalPlayerScores = initialPlayerScores;

        for (int i = 0; i < playerName.Length; i++)
        {
            int symbolValue = playerName[i];

            if (symbolValue % 2 == 0)
            {
                totalPlayerScores += symbolValue;
            }
            else
            {
                totalPlayerScores -= symbolValue;
            }
        }

        return totalPlayerScores;
    }
}

