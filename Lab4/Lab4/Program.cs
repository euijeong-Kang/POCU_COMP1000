using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            MultiSet set = new MultiSet();

            set.Add("cattle");
            set.Add("bee");
            set.Add("cattle");
            set.Add("bee");
            set.Add("happy");
            set.Add("zachariah");

            Debug.Assert(set.Remove("zachariah"));
            Debug.Assert(!set.Remove("fun"));

            Debug.Assert(set.GetMultiplicity("cattle") == 2);

            List<string> expectedList = new List<string> { "bee", "bee", "cattle", "cattle", "happy" };
            List<string> list = set.ToList();

            Debug.Assert(list.Count == 5);

            for (int i = 0; i < expectedList.Count; i++)
            {
                Debug.Assert(expectedList[i] == list[i]);
            }

            MultiSet set2 = new MultiSet();

            set2.Add("cattle");
            set2.Add("bee");
            set2.Add("cattle");
            set2.Add("bee");
            set2.Add("happy");

            list = set.Union(set2).ToList();
            Debug.Assert(list.Count == 5);

            for (int i = 0; i < expectedList.Count; i++)
            {
                Debug.Assert(expectedList[i] == list[i]);
            }

        }
    }
}
