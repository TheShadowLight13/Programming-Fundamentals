using System;
using System.Web;

class Strawberry
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int handlePartHeight = n/2;
        int fruitPartHeight = (n*2 + 1) - handlePartHeight;
        int innerDash = n;
        int outerDash = 0;

        int upperFruitPart = handlePartHeight + 1;

        // Print the handle of strawberry
        for (int i = 0; i < handlePartHeight; i++)
        {
            Console.WriteLine("{0}\\{1}|{1}/{0}", 
                new string('-', outerDash), new string('-', innerDash));
            outerDash += 2;
            innerDash -= 2;
        }

        outerDash = n;
        int dots = 1;
        
        // Print the fruit part
        for (int i = 1; i <= fruitPartHeight; i++)
        {
            if (i <= upperFruitPart)
            {
                Console.WriteLine("{0}#{1}#{0}",
                    new string('-', outerDash), new  string('.', dots));
                outerDash -= 2;
                dots += 4;
            }
            else if (i == upperFruitPart + 1)
            {
                dots -= 2;
                Console.WriteLine("#{0}#", new string('.', dots));

                dots -= 2;
                outerDash += 2;
            }
            else
            {
                Console.WriteLine("{0}#{1}#{0}",
                    new string('-', outerDash), new string('.', dots));
                outerDash++;
                dots -= 2;
            }
        }
    }
}

