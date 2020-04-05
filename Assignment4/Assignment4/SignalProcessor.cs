using System.Drawing;
using System;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Assignment4
{
    public static class SignalProcessor
    {
        public static double[] GetGaussianFilter1D(double sigma)
        {
            int arrayLength = (int)Math.Ceiling(sigma * 6);
            if (arrayLength % 2 == 0)
            {
                arrayLength++;
            }

            double[] result = new double[arrayLength];
            int x = result.Length / 2;

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = 1 / (sigma * Math.Sqrt(2 * Math.PI)) * Math.Pow(Math.E, -(x - i) * (x - i) / (2 * sigma * sigma));

            }

            return result;
        }

        public static double[] Convolve1D(double[] signal, double[] filter)
        {
            double[] result = new double[signal.Length];
            int fiterMedianIndex = filter.Length / 2;


            double[] reverseFilter = new double[filter.Length];
            Array.Copy(filter, reverseFilter, filter.Length);
            Array.Reverse(reverseFilter);

            for (int i = 0; i < signal.Length; i++)
            {
                double[] mulFiter = new double[signal.Length];
                if (i < fiterMedianIndex)
                {
                    Array.ConstrainedCopy(reverseFilter, fiterMedianIndex - i, mulFiter, 0, reverseFilter.Length - fiterMedianIndex + i);
                    result[i] = GetSum(signal, mulFiter);

                }
                else if (i + fiterMedianIndex > signal.Length - 1)
                {
                    Array.ConstrainedCopy(reverseFilter, 0, mulFiter, i - fiterMedianIndex, reverseFilter.Length - fiterMedianIndex + signal.Length - 1 - i);
                    result[i] = GetSum(signal, mulFiter);
                }
                else
                {
                    Array.ConstrainedCopy(reverseFilter, 0, mulFiter, i - fiterMedianIndex, reverseFilter.Length);
                    result[i] = GetSum(signal, mulFiter);
                }
            }

            return result;
        }

        public static double[,] GetGaussianFilter2D(double sigma)
        {
            int arrayLength = (int)(sigma * 6);
            if (arrayLength % 2 == 0 || arrayLength == 0)
            {
                arrayLength++;
            }

            double[,] result = new double[arrayLength, arrayLength];
            int x = result.GetLength(0) / 2;

             for (int i = 0; i < result.GetLength(0); ++i)
             {
                 for (int j = 0; j < result.GetLength(1); ++j)
                 {
                     result[i, j] = 1 / (sigma * sigma * 2 * Math.PI) * Math.Pow(Math.E, -((x - i) * (x - i) + (x - j) * (x - j)) / (2 * sigma * sigma));
                 }
                
             }
            return result;
        }
        public static Bitmap ConvolveImage(Bitmap bitmap, double[,] filter)
        {
            Bitmap result = new Bitmap(bitmap.Width, bitmap.Height);
            filter = Rotate90Degrees(filter);
            int fiterMedianIndex = filter.GetLength(0) / 2;
            int x;
            int y;

            double[,] mulFilter = new double[filter.GetLength(0), filter.GetLength(1)];
            for (int i = 0; i < fiterMedianIndex * 2 + 1; i++)
            {
                for (int j = 0; j < fiterMedianIndex * 2 + 1; j++)
                {
                    mulFilter[i, j] = filter[2 * fiterMedianIndex - i, 2 * fiterMedianIndex - j];
                }
            }

            int[,] red = new int[bitmap.Width, bitmap.Height];
            int[,] green = new int[bitmap.Width, bitmap.Height];
            int[,] blue = new int[bitmap.Width, bitmap.Height];

            for (x = 0; x < bitmap.Width; x++)
            {
                for (y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    red[x, y] = color.R;
                    green[x, y] = color.G;
                    blue[x, y] = color.B;
                }
            }

            double[,] redResult = new double[bitmap.Width, bitmap.Height];
            double[,] greenResult = new double[bitmap.Width, bitmap.Height];
            double[,] blueResult = new double[bitmap.Width, bitmap.Height];

            for (x = 0; x < bitmap.Width; x++)
            {
                for (y = 0; y < bitmap.Height; y++)
                {
                    for (int i = 0; i < fiterMedianIndex * 2 + 1; i++)
                    {
                        for (int j = 0; j < fiterMedianIndex * 2 + 1; j++)
                        {
                            if (x - fiterMedianIndex + i >= 0 && x - fiterMedianIndex + i < bitmap.Width && y - fiterMedianIndex + j >= 0 && y - fiterMedianIndex + j < bitmap.Height)
                            {
                                redResult[x, y] += red[x - fiterMedianIndex + i, y - fiterMedianIndex + j] * mulFilter[i, j];
                                greenResult[x, y] += green[x - fiterMedianIndex + i, y - fiterMedianIndex + j] * mulFilter[i, j];
                                blueResult[x, y] += blue[x - fiterMedianIndex + i, y - fiterMedianIndex + j] * mulFilter[i, j];
                            }

                        }
                    }
                    if (redResult[x, y] < 0)
                    {
                        redResult[x, y] = 0;
                    }
                    else if (redResult[x, y] > 255)
                    {
                        redResult[x, y] = 255;
                    }
                    if (greenResult[x, y] < 0)
                    {
                        greenResult[x, y] = 0;
                    }
                    else if (greenResult[x, y] > 255)
                    {
                        greenResult[x, y] = 255;
                    }
                    if (blueResult[x, y] < 0)
                    {
                        blueResult[x, y] = 0;
                    }
                    else if (blueResult[x, y] > 255)
                    {
                        blueResult[x, y] = 255;
                    }
                    result.SetPixel(x, y, Color.FromArgb((int)redResult[x, y], (int)greenResult[x, y], (int)blueResult[x, y]));
                }
            }
            return result;
        }

        public static double GetSum(double[] signal, double[] mulFiter)
        {
            double sum = 0;
            for (int j = 0; j < mulFiter.Length; j++)
            {
                if (mulFiter[j] != 0)
                {
                    sum += signal[j] * mulFiter[j];
                }
            }
            return sum;
        }
        public static double[,] Rotate90Degrees(double[,] data)
        {
            int rowCount = data.GetLength(0);
            int columnCount = data.GetLength(1);
            double[,] result = new double[columnCount, rowCount];

            for (int i = 0; i < columnCount; i++)
            {
                for (int j = 0; j < rowCount; j++)
                {
                    result[i, j] = data[rowCount - 1 - j, i];
                }
            }
            return result;
        }
        public static double[] GetRowOrNull(double[,] matrix, int row)
        {
            double[] result = new double[matrix.GetLength(1)];
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
    }
}