using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Lab4
{
    public sealed class MultiSet
    {
        public string[] Result;

        public void Add(string element)
        {
            string result;
            if (Result == null)
            {
                result = $"{element}";
            }
            else
            {
                result = string.Join(",", Result);
                result += $",{element}";
            }
            string[] elements = result.Split(",");
            Array.Sort(elements);
            Result = elements;
        }
        public bool Remove(string element)
        {
            string[] copyArray = new string[Result.Length - 1];
            bool bContain = false;

            if (Result.Contains(element)) bContain = true;
           
            if (bContain == true)
            {
                uint copyIndexCount = 0;
                bool check = true;

                for (int i = 0; i < copyArray.Length; i++)
                {
                    if (check == true && Result[i] == element)
                    {
                        check = false;
                        copyIndexCount++;
                    }
                    copyArray[i] = Result[i + copyIndexCount];
                }
                Result = copyArray;
            }
            
            return bContain;
        }
        public uint GetMultiplicity(string element)
        {
            uint count = 0;
            for (int i = 0; i < Result.Length; i++)
            {
                if (Result[i] == element)
                {
                    count++;
                }
            }
            return count;
        }


        public List<string> ToList()
        {
            List<string> result = new List<string>();
            for (int i = 0; i < Result.Length; i++)
            {
                result.Add(Result[i]);
            }
            return result;
        }

        public MultiSet Union(MultiSet other)
        {
            List<string> set1 = Result.ToList();
            for (int i = 0; i < other.Result.Length; i++)
            {
                if (!set1.Contains(other.Result[i]))
                {
                    set1.Add(other.Result[i]);
                }
            }
            MultiSet union = new MultiSet();
            union.Result = set1.ToArray();
            Array.Sort(union.Result);
            return union;
        }

        public MultiSet Intersect(MultiSet other)
        {
            MultiSet intersect = new MultiSet();
            if (CheckEquivalent(other) == true)
            {
                intersect = this;
            }
            MultiSet copySet = new MultiSet();
            copySet.Result = Result;
            List<string> set1 = new List<string>();
            for (int i = 0; i < copySet.Result.Length; i++)
            {
                for (int j = 0; j < other.Result.Length; j++)
                {
                    if (copySet.Result[i] == other.Result[j])
                    {
                        set1.Add(other.Result[j]);
                        copySet.Remove(copySet.Result[i]);
                    }
                }
            }
            
            intersect.Result = set1.ToArray();
            if (set1.Count == 0)
            {
                intersect.Result = new string[] {null};
            }
            return intersect;
            
        }

        public MultiSet Subtract(MultiSet other)
        {
            MultiSet subtrack = new MultiSet();
            if (CheckEquivalent(other) == true)
            {
                subtrack.Result = new string[] { null };
            }
            else
            {
                subtrack.Result = Result;
                for (int i = 0; i < subtrack.Result.Length; i++)
                {
                    for (int j = 0; j < other.Result.Length; j++)
                    {
                        if (subtrack.Result[i] == other.Result[j])
                        {

                            subtrack.Remove(other.Result[i]);

                        }
                    }
                }
            }
            if (subtrack.Result.Length == 0)
            {
                subtrack.Result = new string[] {null};
            }

            return subtrack;

        }

        public List<MultiSet> FindPowerSet()
        {
            

            List<MultiSet> result = new List<MultiSet>();
            for (int i = 0; i < (1 << Result.Length); i++)
            {
                MultiSet powerSet = new MultiSet();
                for (int j = 0; j < Result.Length; j++)
                {
                    if ((i & (1 << j)) != 0)
                    {
                        powerSet.Add(Result[j]);
                    }
                    
                }
                result.Add(powerSet);
            }
            result.Sort();

            return result;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            MultiSet intersect = Intersect(other);
            bool bSubset = false;

            if (intersect.Result.Length == Result.Length)
            {
                bSubset = true;
            }

            return bSubset;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            bool bSuperset = false;
            MultiSet intersect = Intersect(other);
            if (intersect.CheckEquivalent(other) == true)
            {
                bSuperset = true;
            }
            return bSuperset;
        }
        public bool CheckEquivalent(MultiSet other)
        {
            bool check = false;

            if (Result.Length == other.Result.Length)
            {
                for (int i = 0; i < Result.Length; i++)
                {
                    if (Result[i] == other.Result[i])
                    {
                        check = true;
                    }
                }
            }
            return check;
        }
    }
    
}