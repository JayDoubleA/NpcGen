using System;
using NpcGen.Interfaces;
using NpcGen.Models.NpcModels;
using NpcGen.Enums;

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