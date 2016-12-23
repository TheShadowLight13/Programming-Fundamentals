using System;
using System.Collections.Generic;
using System.Linq;

class Portal
{
    static void Main()
    {
        int matrixSize = int.Parse(Console.ReadLine());

        int startRow = 0;
        int startCol = 0;

        List<string> cellsList = new List<string>();
        for (int i = 0; i < matrixSize; i++)
        {
            cellsList.Add(Console.ReadLine());
        }

        int rows = matrixSize;
        int columns = cellsList.Max().Count();

        char[,] matrix = new char[rows, columns];

        for (int row = 0; row < rows; row++)
        {
            string cells = cellsList[row];

            for (int col = 0; col < cells.Length; col++)
            {
                char currentCell = cells[col];
                if (currentCell == 'S')
                {
                    startRow = row;
                    startCol = col;
                }
                matrix[row, col] = currentCell;
            }
        }

        string path = Console.ReadLine();
        MoveInMatrix(matrix, path, startRow, startCol);
    }

    public static void MoveInMatrix(char[,] matrix, string path,
        int startRow, int startCol)
    {
        int movesCounter = 0;

        for (int i = 0; i < path.Length; i++)
        {
            if (path[i] == 'U')
            {
                MoveVertical(-1, matrix, ref startRow, ref startCol);
            }
            else if (path[i] == 'D')
            {
                MoveVertical(+1, matrix, ref startRow, ref startCol);
            }
            else if (path[i] == 'L')
            {
                MoveHorizontal(-1, matrix, ref startRow, ref startCol);
            }
            else if (path[i] == 'R')
            {
                MoveHorizontal(+1, matrix, ref startRow, ref startCol);
            }
            movesCounter++;

            if (matrix[startRow, startCol] == 'E')
            {
                Console.WriteLine($"Experiment successful. {movesCounter} turns required.");
                return;
            }
        }

        Console.WriteLine($"Robot stuck at {startRow} {startCol}. Experiment failed.");
    }

    public static void MoveVertical(int direction, char[,] matrix,
        ref int startRow, ref int startCol)
    {
        do
        {
            startRow += direction;

            if (startRow < 0)
            {
                startRow = matrix.GetLength(0) - 1;
            }
            else if (startRow >= matrix.GetLength(0))
            {
                startRow = 0;
            }

        } while (matrix[startRow, startCol] == '\0');
    }

    public static void MoveHorizontal(int direction, char[,] matrix,
        ref int startRow, ref int startCol)
    {
        do
        {
            startCol += direction;

            if (startCol < 0)
            {
                startCol = matrix.GetLength(1) - 1;
            }
            else if (startCol >= matrix.GetLength(1))
            {
                startCol = 0;
            }

        } while (matrix[startRow, startCol] == '\0');
    }
}

