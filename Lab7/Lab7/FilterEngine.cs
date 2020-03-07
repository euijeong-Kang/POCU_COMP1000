using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    public static class FilterEngine
    {
        public static List<Frame> FilterFrames(List<Frame> frames, EFeatureFlags features)
        {
            List<Frame> result = new List<Frame>();
            for (int i = 0; i < frames.Count; i++)
            {
                if ((frames[i].Features & features) != 0)
                {
                    result.Add(frames[i]);
                }
            }
            return result;
        }
        public static List<Frame> FilterOutFrames(List<Frame> frames, EFeatureFlags features)
        {
            List<Frame> result = new List<Frame>();
            for (int i = 0; i < frames.Count; i++)
            {
                if ((frames[i].Features & features) == 0)
                {
                    result.Add(frames[i]);
                }
            }
            return result;
        }
        public static List<Frame> Intersect(List<Frame> frames1, List<Frame> frames2)
        {
            List<Frame> result = new List<Frame>();
            for (int i = 0; i < frames1.Count; i++)
            {
                for (int j = 0; j < frames2.Count; j++)
                {
                    if (frames1[i] == frames2[j])
                    {
                        result.Add(frames2[j]);
                    }
                }
            }
            return result;
        }
        public static List<int> GetSortKeys(List<Frame> frames, List<EFeatureFlags> features)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < frames.Count; i++)
            {
                byte sortKey = 0;
                for (int j = 0; j < features.Count; j++)
                {
                    if ((frames[i].Features & features[j]) != 0)
                    {
                        byte mask = (byte)(1 << (features.Count - j));
                        sortKey |= mask;
                    }
                }
                result.Add(sortKey);

            }
            return result;
        }
    }
}
