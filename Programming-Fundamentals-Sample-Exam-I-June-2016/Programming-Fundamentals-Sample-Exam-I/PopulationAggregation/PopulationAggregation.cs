using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class PopulationAggregation
{
    static void Main()
    {
        Dictionary<string, int> citiesCountByCountry = new Dictionary<string, int>();
        Dictionary<string, ulong> populationByCity = new Dictionary<string, ulong>();

        string country = string.Empty;
        string city = string.Empty;
        ulong population = 0;

        string input = Console.ReadLine();
        while (input != "stop")
        {
            string[] items = input.Split('\\');
            string[] cleanItems = RemoveProhibitedSymbols(items);

            if (char.IsUpper(cleanItems.First(), 0))
            {
                country = cleanItems[0];
                city = cleanItems[1];
                population = ulong.Parse(cleanItems[2]);
            }
            else
            {
                city = cleanItems[0];
                country = cleanItems[1];
                population = ulong.Parse(cleanItems[2]);
            }

            AddCitiesCountByCountry(citiesCountByCountry, country);
            AddPopulationByCity(populationByCity, city, population);

            input = Console.ReadLine();
        }

        citiesCountByCountry = citiesCountByCountry.OrderBy(c => c.Key)
            .ToDictionary(c => c.Key, c => c.Value);
        populationByCity = populationByCity.OrderByDescending(p => p.Value).Take(3)
            .ToDictionary(c => c.Key, p => p.Value);

        PrintResult(citiesCountByCountry, populationByCity);
    }

    private static string[] RemoveProhibitedSymbols(string[] items)
    {
        string[] cleanItems = new string[items.Length];

        Regex pattern = new Regex("[@#$&0123456789]");
        for (int i = 0; i < items.Length; i++)
        {
            if (i != items.Length - 1)
            {
                cleanItems[i] = pattern.Replace(items[i], "");
            }
            else
            {
                cleanItems[i] = items[i];
            }
        }

        return cleanItems;
    }

    private static void AddCitiesCountByCountry(Dictionary<string, int> citiesCountByCountry,
        string country)
    {
        if (!citiesCountByCountry.ContainsKey(country))
        {
            citiesCountByCountry[country] = 0;
            citiesCountByCountry[country]++;
        }
        else
        {
            citiesCountByCountry[country]++;
        }
    }

    private static void AddPopulationByCity(Dictionary<string, ulong> populationByCity,
        string city, ulong population)
    {
        if (!populationByCity.ContainsKey(city))
        {
            populationByCity[city] = 0;
            populationByCity[city] = population;
        }
        else
        {
            populationByCity[city] = population;
        }
    }

    private static void PrintResult(Dictionary<string, int> citiesCountByCountry,
        Dictionary<string, ulong> populationByCity)
    {
        // Print cities count by countries
        foreach (var country in citiesCountByCountry)
        {
            Console.WriteLine($"{country.Key} -> {country.Value}");
        }

        // Print population by cities
        foreach (var city in populationByCity)
        {
            Console.WriteLine($"{city.Key} -> {city.Value}");
        }
    }
}

