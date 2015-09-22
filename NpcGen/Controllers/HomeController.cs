using System.Web.Mvc;
using System.Linq;
using NpcGen.ControllerHelpers;
using NpcGen.DataAccess;
using NpcGen.Models.NpcModels;
using NpcGen.Extensions;

namespace NpcGen.Controllers
{
    public class HomeController : Controller
    {
        private readonly NpcContext _context = new NpcContext();

        [HttpGet]
        public ActionResult Index()
        {
            var helper = new NpcGenHelper(_context);
            //var model = helper.RandomNpcGet();

            var model = new NpcModel { Para = new NpcGenParamsModel() };

            ViewBag.Classes = _context.Classes.Select(x => x.Name);
            ViewBag.HasNpc = false;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(NpcModel model, string clsName)
        {
            var helper = new NpcGenHelper(_context);
            model = clsName.NotNullOrEmpty() ? helper.NpcGet(clsName, model) : helper.RandomNpcGet();

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