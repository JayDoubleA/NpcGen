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
            var qs = Request.QueryString;
            if (qs["seed"] != null)
            {
                var config = new Configuration();
                config.SeedDebug(_context);
            }
            
            return View();
        }

        public ActionResult Advanced()
        {
            var model = new NpcModel { Para = new NpcGenParamsModel { ExperienceLevel = ExperienceLevel.Journeyman } };
         
            ViewBag.HasNpc = false;

            return View(model);
        }

        public ActionResult Helpful()
        {
            var model = new NpcModel { Para = new NpcGenParamsModel { ExperienceLevel = ExperienceLevel.Journeyman } };
         
            ViewBag.HasNpc = false;

            return View(model);
        }
    }
}