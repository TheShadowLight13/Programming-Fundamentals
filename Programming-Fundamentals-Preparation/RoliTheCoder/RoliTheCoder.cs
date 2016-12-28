using System;
using System.Collections.Generic;
using System.Linq;

class RoliTheCoder
{
    static void Main()
    {
        Dictionary<long, string> eventNameById = new Dictionary<long, string>();
        Dictionary<string, List<string>> participantsByEventName = 
            new Dictionary<string, List<string>>();

        string input = Console.ReadLine();

        while (!input.Equals("Time for Code"))
        {
            string[] commands = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            long eventId = long.Parse(commands[0]);
            string eventName = commands[1];
            List<string> participants = commands.Skip(2).ToList();

            if (eventName.StartsWith("#"))
            {
                if (eventNameById.ContainsKey(eventId))
                {
                    string currentEventName = eventNameById[eventId];

                    if (!currentEventName.Equals(eventName))
                    {
                        input = Console.ReadLine();
                        continue;
                    }
                }

                if (!eventNameById.ContainsKey(eventId) && 
                    participantsByEventName.ContainsKey(eventName))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (!eventNameById.ContainsKey(eventId))
                {
                    eventNameById[eventId] = string.Empty;
                    eventNameById[eventId] = eventName;
                }

                if (!participantsByEventName.ContainsKey(eventName))
                {
                    participantsByEventName[eventName] = new List<string>();
                }

                participantsByEventName[eventName].AddRange(participants);
                participantsByEventName[eventName] = participantsByEventName[eventName]
                    .Distinct().ToList();
            }

            input = Console.ReadLine();
        }

        participantsByEventName = participantsByEventName
            .OrderByDescending(v => v.Value.Count)
            .ThenBy(k => k.Key)
            .ToDictionary(k => k.Key, v => v.Value);

        foreach (var eventName in participantsByEventName.Keys)
        {
            int participantsCount = participantsByEventName[eventName].Count;
            List<string> participants = participantsByEventName[eventName].OrderBy(x => x).ToList();

            Console.WriteLine("{0} - {1}", eventName.Substring(1), participantsCount);
            Console.Write("{0}", string.Join("\n", participants));

            if (participants.Count > 0)
            {
                Console.WriteLine();
            }         
        }
    }
}

