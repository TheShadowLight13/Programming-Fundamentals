using System;
using System.Linq;
using System.Text.RegularExpressions;

class NetherRealms
{
    static void Main()
    {
        string[] demonsName = Console.ReadLine().Split(new char[] { ',', ' ', '\t' },
            StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToArray();

        for (int i = 0; i < demonsName.Length; i++)
        {
            string demonName = demonsName[i];
            decimal health = GetHealth(demonName);
            decimal damage = GetDamage(demonName);

            Console.WriteLine("{0} - {1} health, {2:F2} damage",
                demonName, health, damage);
        }
    }

    private static decimal GetDamage(string demonName)
    {
        decimal damage = 0;

        MatchCollection matches = Regex.Matches(demonName, @"[\-\+]?[\d]+(?:[\.]*[\d]+|[\d]*)");
        for (int i = 0; i < matches.Count; i++)
        {

            damage += decimal.Parse(matches[i].Value);
        }

        foreach (var ch in demonName.Where(x => x == '*' || x == '/'))
        {
            if (ch.Equals('*'))
            {
                damage *= 2;
            }
            else if (ch.Equals('/'))
            {
                damage /= 2;
            }
        }

        return damage;
    }

    private static decimal GetHealth(string demonName)
    {
        decimal health = 0;

        MatchCollection matches = Regex.Matches(demonName, @"[^0-9\*\/\-\+\.]");
        foreach (var str in matches)
        {
            foreach (char ch in str.ToString())
            {
                health += ch;
            }
        }

        return health;
    }
}