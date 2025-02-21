﻿using System.Collections.Generic;

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
                result.Sort();
            }
            return result;
        }

        public MultiSet Union(MultiSet other)
        {
            MultiSet union = new MultiSet();
            MultiSet copyUnion = new MultiSet();

            List<string> copyResult = new List<string>();
            List<string> copyOther = new List<string>();
            if (Result != null)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    copyResult.Add(Result[i]);
                }
            }
            if (other.Result != null)
            {
                for (int i = 0; i < other.Result.Count; i++)
                {
                    copyOther.Add(other.Result[i]);
                }
            }
            if (Result == null && other.Result == null)
            {
                return union;
            }
            else
            {
                if (other.Result != null)
                {
                    for (int i = 0; i < copyOther.Count; i++)
                    {
                        copyResult.Add(copyOther[i]);
                    }
                }
                MultiSet intersect = Intersect(other);
                for (int i = 0; i < copyResult.Count; i++)
                {
                    copyUnion.Add(copyResult[i]);
                }
                MultiSet substract = copyUnion.Subtract(intersect);
                for (int i = 0; i < substract.Result.Count; i++)
                {
                    union.Add(substract.Result[i]);
                }
                union.Result.Sort();
                return union;
            }
        }

        public MultiSet Intersect(MultiSet other)
        {
            MultiSet intersect = new MultiSet();
            List<string> copyResult = new List<string>();

            if (Result == null || other.Result == null)
            {
                return intersect;
            }
            else
            {
                if (Result != null)
                {
                    for (int i = 0; i < Result.Count; i++)
                    {
                        copyResult.Add(Result[i]);
                    }
                }
                List<string> copyOther = new List<string>();
                for (int i = 0; i < other.Result.Count; i++)
                {
                    copyOther.Add(other.Result[i]);
                }
                List<string> newResult = copyResult;
                for (int i = 0; i < copyOther.Count; i++)
                {
                    
                    if (copyResult.Contains(copyOther[i]))
                    {
                        newResult.Remove(copyOther[i]);
                        intersect.Add(copyOther[i]);
                    }
                }
                if (intersect.Result != null)
                {
                    intersect.Result.Sort();
                    return intersect;
                }
                else
                {
                    return intersect;
                }
            }

        }

        public MultiSet Subtract(MultiSet other)
        {
            MultiSet subtract = new MultiSet();
            if (Result == null)
            {
                return subtract;
            }
            else if (other.Result == null)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    subtract.Add(Result[i]);
                }
                return subtract;
            }
            else
            {
                List<string> copyResult = new List<string>();
                List<string> copyOther = new List<string>();
                for (int i = 0; i < Result.Count; i++)
                {
                    copyResult.Add(Result[i]);
                }
                for (int i = 0; i < other.Result.Count; i++)
                {
                    copyOther.Add(other.Result[i]);
                }
                for (int i = 0; i < copyOther.Count; i++)
                {
                    if (copyResult.Contains(copyOther[i]))
                    {
                        copyResult.Remove(copyOther[i]);

                    }
                }
                if (copyResult != null)
                {
                    for (int i = 0; i < copyResult.Count; i++)
                    {
                        subtract.Add(copyResult[i]);
                    }

                }
                return subtract;
            }

        }

        public List<MultiSet> FindPowerSet()
        {
            return null;
        }

        public bool IsSubsetOf(MultiSet other)
        {
            bool bIsSubsetOf = false;
            if (Result == null)
            {
                bIsSubsetOf = true;
            }
            else if (Result == null && other.Result == null)
            {
                bIsSubsetOf = false;
            }
            else if (other.Result != null && Intersect(other).Result == null)
            {
                bIsSubsetOf = false;
            }
            else if (other.Result != null && Result.Count == Intersect(other).Result.Count)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    if (Result[i] == Intersect(other).Result[i])
                    {
                        bIsSubsetOf = true;
                    }
                }
            }
            return bIsSubsetOf;
        }

        public bool IsSupersetOf(MultiSet other)
        {
            bool bIsSupersetOf = false;
            if (other.Result == null)
            {
                bIsSupersetOf = true;
            }
            else if (Result == null)
            {
                bIsSupersetOf = false;
            }
            else if (Result != null && Intersect(other).Result == null)
            {
                bIsSupersetOf = false;
            }
            else if (Result != null && Result.Count == Union(other).Result.Count)
            {
                for (int i = 0; i < Result.Count; i++)
                {
                    if (Result[i] == Union(other).Result[i])
                    {
                        bIsSupersetOf = true;
                    }
                }
            }
            return bIsSupersetOf;
        }
    }
}