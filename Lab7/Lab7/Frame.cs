using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    public class Frame
    {
        public uint ID { get; private set; }
        public EFeatureFlags Features { get; private set; } = EFeatureFlags.Default;
        public string Name { get; private set; }

        public Frame(uint id, string name)
        {
            ID = id;
            Name = name;
        }
        public void ToggleFeatures(EFeatureFlags features)
        {
            Features ^= features;
        }
        public void TurnOnFeatures(EFeatureFlags features)
        {
            Features |= features;
        }
        public void TurnOffFeatures(EFeatureFlags features)
        {
            Features &= ~features;
        }
    }
}
