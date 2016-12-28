using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class NetherRealms
{
    static void Main()
    {
        string healthPattern = @"[^0-9\+\-\*\/\.]";
        string damagePattern = @"[+-]?[0-9]*[.]?[0-9]+";

        Dictionary<string, List<decimal>> demonDataByName = new Dictionary<string, List<decimal>>();

        string[] demonsNames = Console.ReadLine().Split(new char[] {',', ' '}, 
            StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < demonsNames.Length; i++)
        {
            string demonName = demonsNames[i];
            int demonHealth = GetDemonHealth(demonName, healthPattern);
            decimal demonDamage = GetDemonDamage(demonName, damagePattern);

            demonDataByName[demonName] = new List<decimal>();
            demonDataByName[demonName].Add(demonHealth);
            demonDataByName[demonName].Add(demonDamage);
        }

        demonDataByName = demonDataByName.OrderBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var demonName in demonDataByName.Keys)
        {
            decimal demonHealth = demonDataByName[demonName][0];
            decimal demonDamage = demonDataByName[demonName][1];


            Console.WriteLine("{0} - {1} health, {2:F2} damage",
                demonName, demonHealth, demonDamage);
        }

    }

    private static decimal GetDemonDamage(string demonName, string damagePattern)
    {
        MatchCollection damageMatches = Regex.Matches(demonName, damagePattern);

        decimal demonDamage = 0;

        foreach (Match match in damageMatches)
        {
            demonDamage += decimal.Parse(match.Value);
        }

        foreach (var symbol in demonName)
        {

            if (symbol.Equals('*'))
            {
                demonDamage *= 2;
            }
            else if (symbol.Equals('/'))
            {
                demonDamage /= 2;
            }
        }

        return demonDamage;

    }

    private static int GetDemonHealth(string demonName, string healthPattern)
    {
        MatchCollection healthMatches = Regex.Matches(demonName, healthPattern);

        int demonHealth = 0;

        foreach (Match match in healthMatches)
        {
            foreach (var symbol in match.Value)
            {
                demonHealth += symbol;
            }
        }

        return demonHealth;
    }
}

