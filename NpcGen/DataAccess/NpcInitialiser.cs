using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NpcGen.DataAccess
{
    public class NpcInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<NpcContext>
    {
    }
}