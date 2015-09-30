using System.Web.Mvc;
using System.Linq;
using NpcGen.ControllerHelpers;
using NpcGen.DataAccess;
using NpcGen.Models.NpcModels;
using NpcGen.Extensions;
using NpcGen.Enums;

namespace NpcGen.Controllers
{
    public class NpcController : Controller
    {
        private readonly NpcContext _context = new NpcContext();

        public ActionResult Npc(NpcModel model, string clsName)
        {
            var helper = new NpcGenHelper(_context);
            model = clsName.NotNullOrEmpty() ? helper.NpcGet(clsName, model) : helper.RandomNpcGet(model);

            ViewBag.Classes = _context.Classes.Select(x => x.Name);
            ViewBag.HasNpc = true;

            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            if (_context != null)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}