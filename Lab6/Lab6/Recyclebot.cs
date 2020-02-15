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
            bool bType = item.Type == EType.Paper || item.Type == EType.Furniture || item.Type == EType.Electronics;
            
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
            List<Item> result = new List<Item>();
            for (int i = 0; i < NonRecycleItems.Count; i++)
            {
                bool bVolume = true;
                bool bTocxic = NonRecycleItems[i].IsToxicWaste;
                bool bPremise = false;
                bool bType = NonRecycleItems[i].Type == EType.Furniture || NonRecycleItems[i].Type == EType.Electronics;

                if (NonRecycleItems[i].Volume == 10 || NonRecycleItems[i].Volume == 11 || NonRecycleItems[i].Volume == 15)
                {
                    bVolume = false;
                }
                if (bVolume == true && bTocxic == false) { }
                else
                {
                    bPremise = true;
                }
                if (bPremise == true && bType == false) { }
                else
                {
                    result.Add(NonRecycleItems[i]);
                }
            }
            return result;
        }
    }   
}
