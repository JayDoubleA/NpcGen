using System.Web.Mvc;
using NpcGen.ControllerHelpers;
using NpcGen.DataAccess;

namespace NpcGen.Controllers
{
    public class HomeController : Controller
    {
        private readonly NpcContext _context = new NpcContext();

        public ActionResult Index()
        {
            var helper = new NpcGenHelper(_context);
            var model = helper.RandomNpcGet();

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