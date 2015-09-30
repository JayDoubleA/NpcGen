using System.Linq;
using System.Web.Mvc;
using NpcGen.DataAccess;
using NpcGen.Enums;
using NpcGen.Migrations;
using NpcGen.Models.NpcModels;

namespace NpcGen.Controllers
{
    public class HomeController : Controller
    {
        private readonly NpcContext _context = new NpcContext();

        // GET: Home
        public ActionResult Index()
        {
            ViewBagger();
            return View();
        }

        public ActionResult Advanced()
        {
            var qs = Request.QueryString;
            if (qs["seed"] != null)
            {
                var config = new Configuration();
                config.SeedDebug(_context);
            }

            var model = new NpcModel { Para = new NpcGenParamsModel { ExperienceLevel = ExperienceLevel.Journeyman } };

            ViewBagger();
            ViewBag.HasNpc = false;

            return View(model);
        }

        public ActionResult Helpful()
        {
            var qs = Request.QueryString;
            if (qs["seed"] != null)
            {
                var config = new Configuration();
                config.SeedDebug(_context);
            }
            
            var model = new NpcModel { Para = new NpcGenParamsModel { ExperienceLevel = ExperienceLevel.Journeyman } };

            ViewBagger();
            ViewBag.HasNpc = false;

            return View(model);
        }

        public void ViewBagger()
        {
            ViewBag.Classes = _context.Classes.Select(x => x.Name);
            ViewBag.Races = _context.Races.Select(x => x.Name);
        }
    }
}