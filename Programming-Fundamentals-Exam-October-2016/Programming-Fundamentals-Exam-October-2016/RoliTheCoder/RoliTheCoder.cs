using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class RoliTheCoder
{
    static void Main()
    {
        List<Event> eventsList = new List<Event>();

        string input = Console.ReadLine();
        while (!input.Equals("Time for Code"))
        {
            string[] inputArgs = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string id = inputArgs[0];
            string eventName = inputArgs[1];
            List<string> participantsList = inputArgs.Skip(2).ToList();

            if (!eventName.StartsWith("#")
                || (eventsList.Any(e => e.ID == id && e.Name != eventName.TrimStart('#'))))
            {
                input = Console.ReadLine();
                continue;
            }

            eventName = eventName.TrimStart('#');

            if (eventsList.Any(e => e.ID == id))
            {
                Event currEvent = eventsList.First(e => e.ID == id);
                currEvent.ParticipantsList.AddRange(participantsList);

            }
            else
            {
                Event currEvent = new Event()
                {
                    ID = id,
                    Name = eventName,
                    ParticipantsList = new List<string>(participantsList)
                };

                eventsList.Add(currEvent);
            }

            input = Console.ReadLine();
        }

        PrintResult(eventsList);
    }

    private static void PrintResult(List<Event> eventsList)
    {

        for (int i = 0; i < eventsList.Count; i++)
        {
            eventsList[i].ParticipantsList = eventsList[i].ParticipantsList.Distinct().ToList();
        }

        eventsList = eventsList.OrderByDescending(e => e.ParticipantsList.Count).ThenBy(e => e.Name)
            .ToList();

        foreach (var currEvent in eventsList)
        {
            string eventName = currEvent.Name;
            List<string> participantsList = currEvent.ParticipantsList.OrderBy(p => p).ToList();

            Console.WriteLine("{0} - {1}", eventName, participantsList.Count);

            if (participantsList.Count > 0)
            {
                Console.WriteLine(string.Join("\n", participantsList));
            }
        }
    }
}

class Event
{
    public string ID { get; set; }
    public string Name { get; set; }
    public List<string> ParticipantsList { get; set; }
}

