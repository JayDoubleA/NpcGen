using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NpcGen.DataAccess;

namespace NpcGen.Helpers
{
    public class SelectListHelper
    {
        private static readonly NpcContext Context = new NpcContext();

        public static List<SelectListItem> ClassesList()
        {
            return Context.Classes.Select(x => new SelectListItem { Text = x.Name, Value = x.Name}).ToList();
        }

        public static List<SelectListItem> RacesList()
        {
            return Context.Races.Select(x => new SelectListItem { Text = x.Name, Value = x.Name }).ToList();
        }

        public static List<SelectListItem> LocationsList()
        {
            return Context.Locations.Select(x => new SelectListItem { Text = x.Name, Value = x.Name }).ToList();
        }
    }
}