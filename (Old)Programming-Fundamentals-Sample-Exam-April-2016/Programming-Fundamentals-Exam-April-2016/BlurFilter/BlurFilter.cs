using System;
using System.Linq;

class BlurFilter
{
    static void Main()
    {
        long blurAmount = long.Parse(Console.ReadLine());
        int[] matrixDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int matrixRows = matrixDimensions[0];
        int matrixCols = matrixDimensions[1];
        long[,] pixelsMatrix = new long[matrixRows, matrixCols];

        for (int row = 0; row < matrixRows; row++)
        {
            long[] numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();

            for (int col = 0; col < matrixCols; col++)
            {
                pixelsMatrix[row, col] = numbers[col];
            }
        }

        int[] blurCoordinates = Console.ReadLine().Split().Select(int.Parse).ToArray();
        ApplyBlurFilter(pixelsMatrix, blurAmount, blurCoordinates);

        PrintResult(pixelsMatrix);

    }

    private static void ApplyBlurFilter(long[,] pixelsMatrix, long blurAmount, int[] blurCoordinates)
    {
        int matrixRows = pixelsMatrix.GetLength(0);
        int matrixCols = pixelsMatrix.GetLength(1);

        int blurRow = blurCoordinates[0];
        int blurCol = blurCoordinates[1];

        int startRow = blurRow - 1;
        int endRow = blurRow + 1;
        int startCol = blurCol - 1;
        int endCol = blurCol + 1;

        for (int row = startRow; row <= endRow; row++)
        {
            for (int col = startCol; col <= endCol; col++)
            {
                if ((row >= 0 && row < matrixRows) && (col >= 0 && col < matrixCols))
                {
                    pixelsMatrix[row, col] += blurAmount;
                }
            }
        }
    }

    private static void PrintResult(long[,] pixelsMatrix)
    {
        int matrixRows = pixelsMatrix.GetLength(0);
        int matrixCols = pixelsMatrix.GetLength(1);

        for (int row = 0; row < matrixRows; row++)
        {
            for (int col = 0; col < matrixCols; col++)
            {
                Console.Write($"{pixelsMatrix[row, col]} ");
            }
            Console.WriteLine();
        }
    }
}

