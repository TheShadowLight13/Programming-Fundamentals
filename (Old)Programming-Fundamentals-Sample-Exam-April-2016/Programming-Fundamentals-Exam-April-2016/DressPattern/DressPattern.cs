using System;

class DressPattern
{
    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        int width = (12 * n) + 2;

        Console.WriteLine("{0}.{0}.{0}", new string('_', 4 * n));

        int underscore = (4*n) - 2;
        int asterisk = 2;
        int belt = 0;

        // Print from sleeve to the armpit
        for (int i = 0; i < 3 * n; i++)
        {
            if (underscore >= 2)
            {
                Console.WriteLine("{0}.{1}.{0}.{1}.{0}",
                    new string('_', underscore),
                    new string('*', asterisk));

                underscore -= 2;
                asterisk += 3;
                continue;
            }

            if (underscore == 0)
            {
                asterisk = (width - 4) / 2;
                underscore -= 2;
                Console.WriteLine(".{0}..{0}.", new string('*', asterisk));
            }
            else
            {
                asterisk = width - 2;
                Console.WriteLine(".{0}.", new string('*', asterisk));
            }
        }

        asterisk = width - (2 * (3 * n));
        Console.WriteLine("{0}{1}{0}",
            new string('.', 3 * n),
            new string('*', asterisk));

        underscore = 3*n;
        belt = width - (2*underscore);
        
        // Print belt
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("{0}{1}{0}",
                new string('_', underscore),
                new string('o', belt));
        }

        asterisk = width - (2*underscore) - 2;
        
        // Print lower part of dress pattern
        for (int i = 0; i < 3 * n; i++)
        {
            Console.WriteLine("{0}.{1}.{0}",
                new string('_', underscore),
                new string('*', asterisk));

            underscore--;
            asterisk += 2;
        }

        Console.WriteLine(new string('.', width));
    }
}

