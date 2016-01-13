using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace NpcGen.Extensions
{
    public static class SelectListExtensions
    {
        public static SelectList PreAppend(this SelectList list, string dataTextField, string selectedValue, bool selected = false)
        {
            var items = new List<SelectListItem>
            {
                new SelectListItem {Selected = selected, Text = dataTextField, Value = selectedValue}
            };
            items.AddRange(list.Items.Cast<SelectListItem>().ToList());
            return new SelectList(items, "Value", "Text");
        }
        public static SelectList Append(this SelectList list, string dataTextField, string selectedValue, bool selected = false)
        {
            var items = list.Items.Cast<SelectListItem>().ToList();
            items.Add(new SelectListItem() { Selected = selected, Text = dataTextField, Value = selectedValue });
            return new SelectList(items, "Value", "Text");
        }
        public static SelectList Default(this SelectList list, string dataTextField, string selectedValue)
        {
            return list.PreAppend(dataTextField, selectedValue, true);
        }
    }
}