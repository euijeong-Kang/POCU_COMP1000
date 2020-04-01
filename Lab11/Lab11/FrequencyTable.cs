using System;
using System.Collections.Generic;

namespace Lab11
{
    public static class FrequencyTable
    {
        public static List<Tuple<Tuple<int, int>, int>> GetFrequencyTable(int[] data, int maxBinCount)
        {
            List<Tuple<Tuple<int, int>, int>> result = new List<Tuple<Tuple<int, int>, int>>();
            int[] minAndMax = GetMinAndMax(data);
            int min = minAndMax[0];
            int max = minAndMax[1];
            int intervalRange = (int)((max - min) / maxBinCount * 10 + 0.9) / 10;

            int[] sortedArray = new int[data.Length];
            Array.Copy(data, sortedArray, data.Length);
            Array.Sort(sortedArray);
            for (int i = 0; i < sortedArray.Length; i++)
            {
                Console.Write($"{sortedArray[i]}, ");
            }
            Console.WriteLine();
            if (min + intervalRange * maxBinCount <= max)
            {
                intervalRange++;
            }
            for (int i = 1; i < maxBinCount; ++i)
            {
                if (min + intervalRange * i > max)
                {
                    maxBinCount = i;
                    break;
                }
            }
            

            int[] counts = new int[maxBinCount];
            int count = 0;
            for (int i = 0; i < sortedArray.Length; i++)
            {
                if (sortedArray[i] < min + intervalRange * (count + 1))
                {
                    counts[count]++;
                }
                else
                {
                    while (true)
                    {
                        if (sortedArray[i] >= min + intervalRange * (count + 1))
                        {
                            count++;
                        }
                        if (sortedArray[i] < min + intervalRange * (count + 1))
                        {
                            counts[count]++;
                            break;
                        }
                    }
                }
            }
            count = 0;
            int rangMin = min;
            for (int i = 0; i < maxBinCount; i++)
            {
                Console.WriteLine(counts[count]);
                result.Add(new Tuple<Tuple<int, int>, int>(new Tuple<int, int>(rangMin, rangMin + intervalRange), counts[count]));
                rangMin += intervalRange;
                count++;
                
            }

            return result;
        }
    

    public static int[] GetMinAndMax(int[] data)
        {
            int[] result = new int[2];

            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] < min) min = data[i];
                if (max < data[i]) max = data[i];
            }
            result[0] = min;
            result[1] = max;
            return result;
        }
    }
}