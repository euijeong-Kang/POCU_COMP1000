using System.Collections.Generic;
using System;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            bool b = false;
            int x = 0;
            int count = 0;
            List<int> result = MakeStepsRecursive(steps, noise, x, count, b);

            Console.WriteLine();
            return result;
        }
        public static List<int> MakeStepsRecursive(int[] steps, INoise noise, int x, int count, bool b)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < steps.Length; i++)
            {
                result.Add(steps[i]);
            }
            for (int i = 0; i < result.Count - 1; i++)
            {
                if (steps.Length >= 2 && x == steps.Length - 1)
                {
                    return result;
                }
                if (steps[x + 1] - steps[x] > 10 || steps[x + 1] - steps[x] < -10 && b == true)
                {
                    double distance = 0.8;
                    while (distance > 0.2)
                    {
                        decimal step = (decimal)((1 - distance) * steps[x] + distance * steps[x + 1]) + noise.GetNext(count);
                        result.Insert(x + 1, (int)step);

                        distance -= 0.2;
                    }
                    steps = result.ToArray();
                    b = false;

                }
                if (steps[x + 1] - steps[x] > 10 || steps[x + 1] - steps[x] < -10)
                {
                    b = true;
                    return MakeStepsRecursive(steps, noise, x, count + 1, b);
                }
            }
            return MakeStepsRecursive(steps, noise, x + 1, count, b);
        }
    }
}