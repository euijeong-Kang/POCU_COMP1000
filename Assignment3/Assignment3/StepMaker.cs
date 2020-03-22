using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    public static class StepMaker
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            return makeStepsRecursive(steps, noise, 0); ;
        }
        
        private static List<int> makeStepsRecursive(int[] steps, INoise noise, int level)
        {
            List<int> result = new List<int>();
            
            for (int i = 0; i < steps.Length - 1; i++)
            {
                int left = steps[i];
                int right = steps[i + 1];
                
                result.Add(left);
                
                if (getDifference(left, right) > 10)
                {
                    int[] split = new int[6];
                    split[0] = left;
                    split[5] = right;
                    
                    for (int j = 1; j < split.Length - 1; j++)
                    {
                        split[j] = lerp(left, right, j, split.Length - 1 - j) + noise.GetNext(level);
                    }
                    
                    List<int> sub = makeStepsRecursive(split, noise, level + 1);
                    result.AddRange(sub.GetRange(1, sub.Count - 2));
                }
            }
            
            result.Add(steps[steps.Length - 1]);
            return result;
        }
        
        private static int getDifference(int p1, int p2)
        {
            return Math.Abs(p1 - p2);
        }
        
        
        private static int lerp(int p1, int p2, int d1, int d2)
        {
            return (d2 * p1 + d1 * p2) / (d1 + d2); ;
        }
        
        /*
        // Normalize Lerp
        private static int lerp(int p1, int p2, decimal d1)
        {
            decimal p = (1 - d1) * p1 + d1 * p2;
            return (int) p;
        }
        */
    }
}