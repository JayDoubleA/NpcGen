using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NpcGen.Helpers
{
    public static class StringHelpers
    {
        public static string ModStringGet(int mod)
        {
            if (mod > 0)
            {
                return string.Format("+{0}", mod);
            }

            if (mod < 0)
            {
                return mod.ToString();
            }

            return string.Empty;
        }
    }
}