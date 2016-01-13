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

        public ActionResult Npc(NpcModel model, string clsName, string raceName)
        {
            var helper = new NpcGenHelper(_context, model);
            model = clsName.NotNullOrEmpty()&&raceName.NotNullOrEmpty() ? helper.NpcGet(clsName, raceName, model) : helper.RandomNpcGet(model);

            ViewBagger();
            ViewBag.HasNpc = true;

            return View(model);
        }

        public void ViewBagger()
        {
            ViewBag.Classes = _context.Classes.Select(x => x.Name);
            ViewBag.Races = _context.Races.Select(x => x.Name);
            ViewBag.Locations = _context.Locations.Select(x => x.Name);            
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