using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class Recyclebot
    {
        public List<Item> RecycleItems;
        public List<Item> NonRecycleItems;

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

            for (int i = 0; i < NonRecycleItems.Count; i++)
            {
                List<double> dumpVolume = new List<double>() { 10, 11, 15 };
                
                if (dumpVolume.Contains(NonRecycleItems[i].Volume) && NonRecycleItems[i].IsToxicWaste == false)
                {
                    bPremise = true;
                }

            }
            for (int i = 0; i < NonRecycleItems.Count; i++)
            {
                if (bPremise == true && (NonRecycleItems[i].Type == EType.Furniture || NonRecycleItems[i].Type == EType.Electronics))
                {
                    dumpList.Add(NonRecycleItems[i]);
                }
            }
            
            return dumpList;
        }
    }
    
}
