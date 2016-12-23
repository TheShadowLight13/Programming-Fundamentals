using System;
using System.Linq;

class TargetMultiplier
{
    static void Main()
    {
        int[] matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int matrixRows = matrixDimensions[0];
        int matrixCols = matrixDimensions[1];

        long[,] matrix = ReadMatrix(matrixRows, matrixCols);

        int[] targetCellDimension = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int targetRow = targetCellDimension[0];
        int targetCol = targetCellDimension[1];

        matrix = ModifyMatrix(matrix, targetRow, targetCol);
        PrintModifiedMatrix(matrix);
    }

    private static long[,] ReadMatrix(int matrixRows, int matrixCols)
    {
        long[,] matrix = new long[matrixRows, matrixCols];

        for (int row = 0; row < matrixRows; row++)
        {
            long[] numbersInLine = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            for (int col = 0; col < matrixCols; col++)
            {
                matrix[row, col] = numbersInLine[col];
            }
        }

        return matrix;
    }

    private static long[,] ModifyMatrix(long[,] matrix, int targetRow, int targetCol)
    {

        long targetCellValue = matrix[targetRow, targetCol];
        long neighborsSum = 0;

        int startRow = targetRow - 1;
        int endRow = targetRow + 1;
        int startCol = targetCol - 1;
        int endCol = targetCol + 1;

        for (int row = startRow; row <= endRow; row++)
        {
            for (int col = startCol; col <= endCol; col++)
            {
                if (!(row == targetRow && col == targetCol))
                {
                    neighborsSum += matrix[row, col];
                    matrix[row, col] *= targetCellValue;
                }
            }
        }

        // Set new value in targeted cell
        matrix[targetRow, targetCol] *= neighborsSum;

        return matrix;
    }

    private static void PrintModifiedMatrix(long[,] matrix)
    {
        int matrixRows = matrix.GetLength(0);
        int matrixCols = matrix.GetLength(1);

        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                Console.Write("{0} ", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}

