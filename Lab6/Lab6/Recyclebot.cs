using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class Recyclebot
    {
        public List<Item> RecycleItems { get; private set; }
        public List<Item> NonRecycleItems { get; private set; }

        public Recyclebot()
        {
            RecycleItems = new List<Item>();
            NonRecycleItems = new List<Item>();
        }
        public void Add(Item item)
        {
            bool bType = true;
            if (item.Type == EType.Glass || item.Type == EType.Compost || item.Type == EType.Plastic)
            {
                bType = false;
            }
            if (bType == true && (item.Weight < 2 || item.Weight >= 5))
            {
                NonRecycleItems.Add(item);
            }
            else
            {
                RecycleItems.Add(item);
            }
        }
        public List<Item> Dump()
        {
            List<Item> dumpList = new List<Item>();
            bool bPremise = false;
            bool bConclusion = false;
            


            for (int i = 0; i < NonRecycleItems.Count; i++)
            {
                if ((NonRecycleItems[i].Volume == 10 || NonRecycleItems[i].Volume == 1) && NonRecycleItems[i].Volume != 15)
                {
                    bPremise = true;
                }
            }
            for (int i = 0; i < NonRecycleItems.Count; i++)
            {
                if (bPremise == true && NonRecycleItems[i].IsToxicWaste == false)
                {
                    bConclusion = false;
                }
                else
                {
                    bConclusion = true;
                }
            }
            for (int i = 0; i < NonRecycleItems.Count; i++)
            {
                bool b = false;
                if (NonRecycleItems[i].Type == EType.Glass || NonRecycleItems[i].Type == EType.Compost || NonRecycleItems[i].Type == EType.Plastic || NonRecycleItems[i].Type == EType.Paper)
                {
                    b = true;
                }
                if (bConclusion == true && b == true) {}
                else
                {
                    dumpList.Add(NonRecycleItems[i]);
                }
            }
            return dumpList;
        }
    
    }
    
}
