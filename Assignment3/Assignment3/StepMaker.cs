using System.Collections.Generic;
using System;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            int x = 0;
            int count = 0;
            List<int> result = MakeStepsRecursive(steps, noise, ref x, ref count);
            
            return result;
        }
        public static List<int> MakeStepsRecursive(int[] steps, INoise noise, ref int x, ref int count)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < steps.Length; i++)
            {
                result.Add(steps[i]);
            }
            if (steps.Length > 2 && x == steps.Length - 1)
            {
                return result;
            }
            if (steps[x + 1] - steps[x] > 10)
            {
                
                double distance = 0.8;
                while (distance > 0.2)
                {
                    int step = (int)((((1 - distance) * steps[x] + distance * steps[x + 1]) * 10 + 0.5) / 10) + noise.GetNext(count);
                    result.Insert(x + 1, step);
                    distance -= 0.2;
                }
                count = 1;
            }
            else
            {
                x++;
            }
            steps = result.ToArray();
            return MakeStepsRecursive(steps, noise, ref x, ref count);

        }
    }
}