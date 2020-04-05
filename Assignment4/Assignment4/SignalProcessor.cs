using System.Drawing;
using System;
using System.Drawing.Imaging;

namespace Assignment4
{
    public static class SignalProcessor
    {
        public static double[] GetGaussianFilter1D(double sigma)
        {
            int arrayLength = (int)(sigma * 6);
            if (arrayLength % 2 == 0)
            {
                arrayLength++;
            }

            double[] result = new double[arrayLength];
            int x = result.Length / 2 * -1;

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = 1 / (sigma * Math.Sqrt(2 * Math.PI)) * Math.Exp(-1 * (x * x) / (2 * sigma * sigma));
                x++;
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
                    Array.ConstrainedCopy(reverseFilter, 0 , mulFiter, i - fiterMedianIndex, reverseFilter.Length - fiterMedianIndex + signal.Length - 1 - i);
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
            if (arrayLength % 2 == 0)
            {
                arrayLength++;
            }

            double[,] result = new double[arrayLength, arrayLength];
            int x = result.GetLength(0) / 2 * -1;

            for (int i = 0; i < result.GetLength(0); i++)
            {
                int y = result.GetLength(1) / 2 * -1;
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = 1 / (sigma * sigma * 2 * Math.PI) * Math.Exp(-1 * (x * x + y * y) / (2 * sigma * sigma));
                    y++;
                }
                x++;
            }
            return result;
        }

        public static Bitmap ConvolveImage(Bitmap bitmap, double[,] filter)
        {
            Bitmap resultBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            double[,] reversedFilter = new double[filter.GetLength(1), filter.GetLength(0)];
            Array.Copy(filter, reversedFilter, filter.Length);
            reversedFilter = Rotate90Degrees(Rotate90Degrees(reversedFilter));
            

            Color[,] colors = new Color[bitmap.Height, bitmap.Width];
            double[,] colorRed = new double[bitmap.Height, bitmap.Width];
            double[,] colorBlue = new double[bitmap.Height, bitmap.Width];
            double[,] colorGreen = new double[bitmap.Height, bitmap.Width];

            Color color;
            Color color1;

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    color = bitmap.GetPixel(j, i);
                    colorRed[i, j] = color.R;
                    colorGreen[i, j] = color.G;
                    colorBlue[i, j] = color.B;
                    Console.Write($"{colorRed[i, j]}, ");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();

            }
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    int redCount = getBla(i, colorRed, reversedFilter);
                    int greenCount = getBla(i, colorGreen, reversedFilter);
                    int blueCount = getBla(i, colorBlue, reversedFilter);
                    
                    color1 = Color.FromArgb(colors[i, j].R + redCount, colors[i, j].G + greenCount, colors[i, j].B + blueCount);
                    resultBitmap.SetPixel(j, i, color1);
                }
                
            }
            return resultBitmap;
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
        public static int getBla(int y, double[,] sig, double[,] filter)
        {
            double sum = 0;
            int startIndex;
            int fiterMedianIndex = filter.GetLength(1) / 2;
            double[] reverseFilter = new double[filter.GetLength(1)];
            double[] signal = new double[sig.GetLength(1)];
            signal = GetRowOrNull(sig, 1);

            int count;
            if (y < fiterMedianIndex)
            {
                startIndex = 0;
                count = reverseFilter.Length - fiterMedianIndex - 1 - y;
                
                for (int i = startIndex; i < reverseFilter.Length - fiterMedianIndex + y; i++)
                {
                    reverseFilter = GetRowOrNull(filter, count);
                    signal = GetRowOrNull(sig, i);
                    for (int j = 0; j < signal.Length; j++)
                    {
                        double[] mulFiter = new double[signal.Length];
                        if (j < fiterMedianIndex)
                        {
                            Array.ConstrainedCopy(reverseFilter, fiterMedianIndex - j, mulFiter, 0, reverseFilter.Length - fiterMedianIndex + j);
                            sum += GetSum(signal, mulFiter);

                        }
                        else if (j + fiterMedianIndex > signal.Length - 1)
                        {
                            Array.ConstrainedCopy(reverseFilter, 0, mulFiter, j - fiterMedianIndex, reverseFilter.Length - fiterMedianIndex + signal.Length - 1 - j);
                            sum += GetSum(signal, mulFiter);
                        }
                        else
                        {
                            Array.ConstrainedCopy(reverseFilter, 0, mulFiter, j - fiterMedianIndex, reverseFilter.Length);
                            sum += GetSum(signal, mulFiter);
                        }
                        
                    }
                    count++;
                }
            }
            else if (y + fiterMedianIndex > signal.Length)
            {
                startIndex = y - fiterMedianIndex;
                count = 0;
                for (int i = startIndex; i < reverseFilter.Length - fiterMedianIndex - (signal.Length - 1 - y); i++)
                {
                    reverseFilter = GetRowOrNull(filter, count);
                    signal = GetRowOrNull(sig, y - fiterMedianIndex);
                    for (int j = 0; j < signal.Length; j++)
                    {
                        double[] mulFiter = new double[signal.Length];
                        if (j < fiterMedianIndex)
                        {
                            Array.ConstrainedCopy(reverseFilter, fiterMedianIndex - j, mulFiter, 0, reverseFilter.Length - fiterMedianIndex + j);
                            sum += GetSum(signal, mulFiter);

                        }
                        else if (j + fiterMedianIndex > signal.Length - 1)
                        {
                            Array.ConstrainedCopy(reverseFilter, 0, mulFiter, j - fiterMedianIndex, reverseFilter.Length - fiterMedianIndex + signal.Length - 1 - j);
                            sum += GetSum(signal, mulFiter);
                        }
                        else
                        {
                            Array.ConstrainedCopy(reverseFilter, 0, mulFiter, j - fiterMedianIndex, reverseFilter.Length);
                            sum += GetSum(signal, mulFiter);
                        }
                        Console.Write($"{sum}");
                    }
                    count++;
                }
            }
            else
            {
                startIndex = y - fiterMedianIndex;
                count = 0;
                for (int i = startIndex; i < reverseFilter.Length; i++)
                {
                    reverseFilter = GetRowOrNull(filter, count);
                    signal = GetRowOrNull(sig, y - fiterMedianIndex);
                    for (int j = 0; j < signal.Length; j++)
                    {
                        double[] mulFiter = new double[signal.Length];
                        if (j < fiterMedianIndex)
                        {
                            Array.ConstrainedCopy(reverseFilter, fiterMedianIndex - j, mulFiter, 0, reverseFilter.Length - fiterMedianIndex + j);
                            sum += GetSum(signal, mulFiter);

                        }
                        else if (j + fiterMedianIndex > signal.Length - 1)
                        {
                            Array.ConstrainedCopy(reverseFilter, 0, mulFiter, j - fiterMedianIndex, reverseFilter.Length - fiterMedianIndex + signal.Length - 1 - j);
                            sum += GetSum(signal, mulFiter);
                        }
                        else
                        {
                            Array.ConstrainedCopy(reverseFilter, 0, mulFiter, j - fiterMedianIndex, reverseFilter.Length);
                            sum += GetSum(signal, mulFiter);
                        }
                    }
                    count++;
                }
            }
            return (int)sum;
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