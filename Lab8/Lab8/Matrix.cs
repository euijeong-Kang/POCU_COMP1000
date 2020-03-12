using System;
using System.Collections.Generic;
using System.Text;

namespace Lab8
{
    public static class Matrix
    {
        public static int DotProduct(int[] v1, int[] v2)
        {
            int result = 0;
            if ( v1.Length == v2.Length)
            {
                for (int i = 0; i < v1.Length; i++)
                {
                    result += v1[i] * v2[i];
                }
            }
            return result;
        }
        public static int[,] Transpose(int[,] matrix)
        {
            int column = matrix.GetLength(1);
            int row = matrix.GetLength(0);
            int[,] result = new int[column, row];
            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    result[i, j] = matrix[j, i];
                }
            }
            return result;
        }
        public static int[,] GetIdentityMatrix(int size)
        {
            int[,] result = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        result[i, j] = 1;
                    }
                    else
                    {
                        result[i, j] = 0;
                    }
                }
            }
            return result;
        }
        public static int[] GetRowOrNull(int[,] matrix, int row)
        {
            int[] result = new int[matrix.GetLength(1)];
            if (row > matrix.GetLength(0) - 1 || row < 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    result[i] = matrix[row, i];
                }   
            }
            return result;
        }
        public static int[] GetColumnOrNull(int[,] matrix, int col)
        {
            int[] result = new int[matrix.GetLength(0)];
            if (col > matrix.GetLength(1) - 1 || col < 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    result[i] = matrix[i, col];
                }
            }
            return result;
        }
        public static int[] MultiplyMatrixVectorOrNull(int[,] matrix, int[] vector)
        {
            int[] result = new int[matrix.GetLength(0)];
            if (matrix.GetLength(1) != vector.Length)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        result[i] += matrix[i, j] * vector[j];
                    }
                }
            }
            return result;
        }
        public static int[] MultiplyVectorMatrixOrNull(int[] vector, int[,] matrix)
        {
            int[] result = new int[matrix.GetLength(1)];
            if (matrix.GetLength(0) != vector.Length)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    {
                        result[i] += matrix[j, i] * vector[j];
                    }
                }
            }
            return result;
        }
        public static int[,] MultiplyOrNull(int[,] multiplicandMatrix, int[,] multiplierMatrix)
        {
            if (multiplicandMatrix.GetLength(1) != multiplierMatrix.GetLength(0))
            {
                return null;
            }
            int column = multiplicandMatrix.GetLength(0);
            int row = multiplierMatrix.GetLength(1);
            int[,] result = new int[column, row];

            for (int i = 0; i < result.GetLength(0); i++)
            {
                int[] rowMultiplicandMatrix = GetRowOrNull(multiplicandMatrix, i);
                int[] mutilply = MultiplyVectorMatrixOrNull(rowMultiplicandMatrix, multiplierMatrix);
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = mutilply[j];
                }
            }
            return result;



        }
    }
}
