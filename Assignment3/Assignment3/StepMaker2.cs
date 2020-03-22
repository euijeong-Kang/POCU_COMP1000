using System.Collections.Generic;

namespace Assignment3
{
    public static class StepMakers
    {
        public static List<int> MakeSteps(int[] steps, INoise noise)
        {
            List<int> listResults = new List<int>() { steps[0] };
            for (int i = 1; i < steps.Length; ++i)
            {
                makeStepsRecursive(steps[i - 1], steps[i], 0, listResults, noise);
            }
            return listResults;
        }
        
        private static void makeStepsRecursive(int p, int q, int level, List<int> list, INoise noise)
        {
            if (getAbs(p - q) <= 10)
            {
                list.Add(q);
                return;
            }
            int[] newSteps = new int[6];
            newSteps[0] = p;
            for (int i = 1; i <= 4; ++i)
            {
                float linearInterpolation = 0.2f * i * q + (1.0f - 0.2f * i) * p;
                float epsilon = linearInterpolation >= 0 ? 0.1f : -0.1f;
                newSteps[i] = (int)(linearInterpolation + epsilon) + noise.GetNext(level);
            }
            newSteps[5] = q;
            for (int i = 1; i < 6; ++i)
            {
                makeStepsRecursive(newSteps[i - 1], newSteps[i], level + 1, list, noise);
            }
        }
      

        private static int getAbs(int num)
        {
            return num < 0 ? -num : num;
        }
    }
}