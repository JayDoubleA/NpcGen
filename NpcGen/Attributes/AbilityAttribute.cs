using System;
using NpcGen.Interfaces;
using NpcGen.Models.NpcModels;

namespace NpcGen.Attributes
{
    public class AbilityAttribute : Attribute, IAttribute<Abilities>
    {
        public AbilityAttribute(Abilities stat)
        {
            Value = stat;
        }

        public Abilities Value { get; private set; }
    }
}