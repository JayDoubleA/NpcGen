using System;
using System.Collections.Generic;
using System.Linq;
using NpcGen.DataAccess;
using NpcGen.Extensions;
using NpcGen.Models.NpcModels;

namespace NpcGen.Helpers
{
    public static class ObjectGeneratorHelpers
    {
        public static List<AttackPropertyModel> AttackPropertiesFromCommaList(string commaList, List<AttackPropertyModel> localContext = null )
        {
            
            var context = new NpcContext();
            var props = commaList.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var list = new List<AttackPropertyModel>();

            if (commaList.IsNullOrEmpty())
            {
                return list;
            }

            foreach (var prop in props)
            {
                var contextProps = localContext ?? context.AttackProperties.ToList();

                var attackProp = contextProps.FirstOrDefault(a => a.Name.ToLower().Equals(prop.Trim().ToLower()));

                list.Add(attackProp ?? new AttackPropertyModel(prop.Trim()));
            }

            return list;
        }
    }
}