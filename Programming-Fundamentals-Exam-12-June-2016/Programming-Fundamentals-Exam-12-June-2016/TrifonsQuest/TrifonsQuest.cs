using System;
using System.Linq;
using System.Threading;

class TrifonsQuest
{
    static void Main()
    {

        long health = long.Parse(Console.ReadLine());
        int[] rowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int rows = rowsCols[0];
        int columns = rowsCols[1];

        char[,] gameField = new char[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            char[] fieldData = Console.ReadLine().ToArray();

            for (int col = 0; col < columns; col++)
            {
                gameField[row, col] = fieldData[col];
            }
        }

        MovePlayerInGameField(health, gameField);
    }

    public static void MovePlayerInGameField(long health, char[,] gameField)
    {
        int rowsCount = gameField.GetLength(0);
        int columnsCount = gameField.GetLength(1);

        int startRow = 0;
        int startCol = 0;

        int turnsCount = 0;

        int dir = 1;

        while (startCol < columnsCount)
        {
            if (dir == 1)
            {
                startRow = 0;
            }
            else
            {
                startRow = rowsCount - 1;
            }

            while (startRow != -1 && startRow != rowsCount)
            {

                char cell = gameField[startRow, startCol];
                if (cell == 'F')
                {
                    health -= turnsCount / 2;
                    turnsCount++;
                }
                else if (cell == 'H')
                {
                    health += turnsCount / 3;
                    turnsCount++;
                }
                else if (cell == 'T')
                {
                    turnsCount += 3;
                }
                else
                {
                    turnsCount++;
                }

                if (health <= 0)
                {
                    Console.WriteLine($"Died at: [{startRow}, {startCol}]");
                    return;
                }

                startRow += dir;
            }
            dir = -dir;
            startCol++;
        }

        Console.WriteLine("Quest completed!");
        Console.WriteLine($"Health: {health}");
        Console.WriteLine($"Turns: {turnsCount}");
    }
}

