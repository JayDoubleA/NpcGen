using System.Web.Mvc;
using System.Linq;
using NpcGen.ControllerHelpers;
using NpcGen.DataAccess;
using NpcGen.Models.NpcModels;
using NpcGen.Extensions;
using NpcGen.Enums;

namespace NpcGen.Controllers
{
    public class HomeController : Controller
    {
        private readonly NpcContext _context = new NpcContext();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Advanced()
        {
            var qs = Request.QueryString;
            if (qs["seed"] != null)
            {
                var config = new Migrations.Configuration();
                config.SeedDebug(_context);
            }

            var helper = new NpcGenHelper(_context);
            //var model = helper.RandomNpcGet();

            var model = new NpcModel { Para = new NpcGenParamsModel { ExperienceLevel = ExperienceLevel.Journeyman } };

            ViewBag.Classes = _context.Classes.Select(x => x.Name);
            ViewBag.HasNpc = false;

            return View(model);
        }

        public ActionResult Helpful()
        {
            var qs = Request.QueryString;
            if (qs["seed"] != null)
            {
                var config = new Migrations.Configuration();
                config.SeedDebug(_context);
            }

            var helper = new NpcGenHelper(_context);

            var model = new NpcModel { Para = new NpcGenParamsModel { ExperienceLevel = ExperienceLevel.Journeyman } };

            ViewBag.Classes = _context.Classes.Select(x => x.Name);
            ViewBag.HasNpc = false;

            return View(model);
        }

        public ActionResult Assisted()
        {
            return View();
        }
    }
}