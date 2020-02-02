using System.Collections.Generic;
using System;

namespace Lab4
{
    public sealed class MultiSet
    {
        public string[] Result;
        public void Add(string element)
        {
            if (Result == null)
            {
                List<string> result = new List<string>();
                result.Insert(0, element);
                Result = result.ToArray(); ;
            }
            else
            {
                List<string> result = ToList();
                result.Insert(0, element);
                Result = result.ToArray();
                Array.Sort(Result);
            }

        }

        public bool Remove(string element)
        {
            bool bContain = false;
            List<string> result = ToList();
            if (result.Contains(element))
            {
                result.Remove(element);
                bContain = true;
                Result = result.ToArray();

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
            result.Sort();
            return result;
        }

        public MultiSet Union(MultiSet other)
        {
            MultiSet union = new MultiSet();
            List<string> result = ToList();
            if (this != null)
            {
                for (int i = 0; i < Result.Length; i++)
                {
                    union.Add(Result[i]);
                }
            }
            if (other.Result != null)
            {
                for (int i = 0; i < other.Result.Length; i++)
                {
                    if (!result.Contains(other.Result[i]))
                    {
                        union.Add(other.Result[i]);
                    }
                }

            }
            Array.Sort(union.Result);

            return union;
        }

        public MultiSet Intersect(MultiSet other)
        {
            MultiSet intersect = new MultiSet();
            List<string> copyReult = new List<string>();
            for (int i = 0; i < Result.Length; i++)
            {
                copyReult.Add(Result[i]);
            }
            if (this != null && other != null)
            {
                for (int i = 0; i < copyReult.Count; i++)
                {
                    for (int j = 0; j < other.Result.Length; j++)
                    {
                        if (copyReult[i] == other.Result[j])
                        {
                            intersect.Add(copyReult[i]);
                            copyReult.RemoveAt(i);
                        }
                    }
                }
            }

            return intersect;
        }

        public MultiSet Subtract(MultiSet other)
        {
            MultiSet substract = new MultiSet();
            MultiSet intersect = Intersect(other);
            List<string> result = ToList();

            if (intersect != null)
            {
                for (int i = 0; i < intersect.Result.Length; i++)
                {
                    if (result.Contains(intersect.Result[i]))
                    {
                        result.Remove(intersect.Result[i]);
                    }
                }
                for (int j = 0; j < result.Count; j++)
                {
                    substract.Add(result[j]);
                }

            }
            return substract;
        }

        public List<MultiSet> FindPowerSet()
        {
            return null;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            bool bIsSubsetOf = false;
            if (this == null)
            {
                bIsSubsetOf = true;
            }
            else if (other.ToList() == Intersect(other).ToList())
            {
                bIsSubsetOf = true;
            }
            return bIsSubsetOf;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            bool bIsSupersetOf = false;
            if (this != null)
            {
                if (other == null)
                {
                    bIsSupersetOf = true;
                }

                else if (ToList().Count == Union(other).ToList().Count)
                {
                    for (int i = 0; i < ToList().Count; i++)
                    {
                        if (ToList()[i] == Union(other).ToList()[i])
                        {
                            bIsSupersetOf = true;
                        }
                    }
                }
            }

            return bIsSupersetOf;
        }
    }
}