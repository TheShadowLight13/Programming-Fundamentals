using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class PopulationAggregation
{
    static void Main()
    {
        string input = Console.ReadLine();

        Dictionary<string, int> citiesCountByCountry = new Dictionary<string, int>();
        Dictionary<string, ulong> populationByCity = new Dictionary<string, ulong>();

        Regex regex = new Regex(@"[@#$&0-9]");

        while (!input.Equals("stop"))
        {
            string[] args = input.Split('\\');

            string country = string.Empty;
            string city = string.Empty;
            ulong population = 0;

            if (char.IsUpper(args[0][0]))
            {
                country = regex.Replace(args[0], "");
                city = regex.Replace(args[1], "");
                population = ulong.Parse(args[2]);
            }
            else
            {
                city = regex.Replace(args[0], "");
                country = regex.Replace(args[1], "");
                population = ulong.Parse(args[2]);
            }

            if (!populationByCity.ContainsKey(city))
            {
                populationByCity[city] = 0;
            }

            populationByCity[city] = population;

            if (!citiesCountByCountry.ContainsKey(country))
            {
                citiesCountByCountry[country] = 0;
            }

            citiesCountByCountry[country]++;

            input = Console.ReadLine();
        }

        citiesCountByCountry = citiesCountByCountry.OrderBy(x => x.Key)
            .ToDictionary(k => k.Key, v => v.Value);

        populationByCity = populationByCity.OrderByDescending(x => x.Value)
            .Take(3).ToDictionary(k => k.Key, v => v.Value);

        foreach (var country in citiesCountByCountry.Keys)
        {
            Console.WriteLine("{0} -> {1}", country, citiesCountByCountry[country]);
        }

        foreach (var city in populationByCity.Keys)
        {
            Console.WriteLine("{0} -> {1}", city, populationByCity[city]);
        }
    }
}

