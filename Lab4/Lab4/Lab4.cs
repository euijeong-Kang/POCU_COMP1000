using System.Collections.Generic;

namespace Lab4
{
    public sealed class MultiSet
    {
        public List<string> Result;

        public void Add(string element)
        {
            if (Result == null)
            {
                List<string> result = new List<string>();
                result.Insert(0, element);
                Result = result;
            }
            else
            {
                List<string> result = Result;
                result.Insert(0, element);
                Result = result;
                Result.Sort();
            }
        }


        public bool Remove(string element)
        {
            bool bContain = false;
            if (Result.Contains(element))
            {
                Result.Remove(element);
                bContain = true;
            }

            return bContain;
        }

        public uint GetMultiplicity(string element)
        {
            uint count = 0;
            for (int i = 0; i < Result.Count; i++)
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
            if (Result != null)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    result.Add(Result[i]);
                }
                
            }
            return result;
        }

        public MultiSet Union(MultiSet other)
        {
            MultiSet union = new MultiSet();
            MultiSet copyOther = new MultiSet();
            if (this != null)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    union.Add(Result[i]);
                }
            }
            if (other.Result != null)
            {
                for (int j = 0; j < other.Result.Count; j++)
                {
                    copyOther.Add(other.ToList()[j]);
                }
                for (int i = 0; i < copyOther.Result.Count; i++)
                {
                    if (!Result.Contains(copyOther.Result[i]))
                    {
                        union.Add(copyOther.Result[i]);
                    }
                }
                union.Result.Sort();
            }

            return union;
        }

        public MultiSet Intersect(MultiSet other)
        {
            MultiSet intersect = new MultiSet();
            MultiSet copyOther = new MultiSet();
            if (other.Result != null)
            {
                for (int j = 0; j < other.Result.Count; j++)
                {
                    copyOther.Add(other.ToList()[j]);
                }
            }
            List<string> copyReult = new List<string>();
            for (int i = 0; i < Result.Count; i++)
            {
                copyReult.Add(Result[i]);
            }
            if (this != null && other != null)
            {
                for (int i = 0; i < copyReult.Count; i++)
                {
                    for (int j = 0; j < copyOther.Result.Count; j++)
                    {
                        if (copyReult[i] == copyOther.Result[j])
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
            MultiSet copyOther = new MultiSet();

            List<string> result = ToList();
            if (other.Result != null)
            {
                for (int j = 0; j < other.Result.Count; j++)
                {
                    copyOther.Add(other.ToList()[j]);
                }
            }
            MultiSet intersect = Intersect(copyOther);

            if (intersect != null)
            {
                for (int i = 0; i < intersect.Result.Count; i++)
                {
                    if (result.Contains(intersect.Result[i]))
                    {
                        result.Remove(intersect.Result[i]);
                    }
                }
                substract.Result = result;
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
                else if (ToList() == Union(other).ToList())
                {
                    bIsSupersetOf = true;
                }
            }

            return bIsSupersetOf;
        }
    }
}