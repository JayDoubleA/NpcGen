using System;
using System.Collections.Generic;
using System.Linq;
using NpcGen.Extensions;
using NpcGen.Models.NpcModels;

namespace NpcGen.Helpers
{
    public static class ObjectGeneratorHelpers
    {
        public static List<AttackPropertyModel> AttackPropertiesFromCommaList(string commaList)
        {
            var list = new List<AttackPropertyModel>();

            if (commaList.IsNullOrEmpty())
            {
                return list;
            }

            var props = commaList.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);

            list.AddRange(props.Select(prop => new AttackPropertyModel(prop.Trim())));

            return list;
        }
    }
}