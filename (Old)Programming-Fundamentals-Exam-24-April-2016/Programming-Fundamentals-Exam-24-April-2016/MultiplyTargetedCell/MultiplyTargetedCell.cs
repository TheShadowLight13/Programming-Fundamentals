using System;
using System.Linq;

class MultiplyTargetedCell
{
    static void Main()
    {
        int[] matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int matrixRows = matrixDimensions[0];
        int matrixCols = matrixDimensions[1];

        int[,] matrix = new int[matrixRows, matrixCols];

        for (int row = 0; row < matrixRows; row++)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int col = 0; col < matrixCols; col++)
            {
                matrix[row, col] = numbers[col];
            }
        }

        int[] targetCellCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int targetCellRow = targetCellCoordinates[0];
        int targetCellCol = targetCellCoordinates[1];

        MultiplyCells(matrix, targetCellRow, targetCellCol);
        PrintResult(matrix);
    }

    private static void MultiplyCells(int[,] matrix, int targetCellRow, int targerCellCol)
    {
        int startRow = targetCellRow - 1;
        int endRow = targetCellRow + 1;
        int startCol = targerCellCol - 1;
        int endCol = targerCellCol + 1;

        int cellsSum = 0;

        for (int row = startRow; row <= endRow; row++)
        {
            for (int col = startCol; col <= endCol; col++)
            {
                if (!row.Equals(targetCellRow) || !col.Equals(targerCellCol))
                {
                    cellsSum += matrix[row, col];
                    matrix[row, col] *= matrix[targetCellRow, targerCellCol];
                }
            }
        }

        matrix[targetCellRow, targerCellCol] *= cellsSum;
    }

    private static void PrintResult(int[,] matrix)
    {
        int matrixRows = matrix.GetLength(0);
        int matrixCols = matrix.GetLength(1);

        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }

            Console.WriteLine();
        }
    }
}

