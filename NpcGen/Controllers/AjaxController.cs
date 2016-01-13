using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using NpcGen.DataAccess;

namespace NpcGen.Controllers
{
    public class AjaxController : Controller
    {
        private readonly NpcContext _context = new NpcContext();

        public JsonResult RacesUpdate(string loc)
        {
            var races = _context.Races.Select(x => x.Name).ToList();
            var location = _context.Locations.FirstOrDefault(x => x.Name.Equals(loc));

            if (location != null)
            {
                races = location.MajorRaces.Select(x => x.Name).ToList();
            }

            var json = JsonConvert.SerializeObject(races);
            var result = new JsonResult {Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            return result;
        }

        public JsonResult UpdateLocations(string rac)
        {
            var locations = _context.Locations.Select(x => x.Name).ToList();
            var race = _context.Races.FirstOrDefault(x => x.Name.Equals(rac));

            if (rac != null)
            {
                locations = (from
                    loc in _context.Locations
                    from
                        raceLoc in loc.MajorRaces
                    where
                        raceLoc.Name.Equals(race.Name)
                    select
                        loc.Name).ToList();
            }

            var json = JsonConvert.SerializeObject(locations);
            var result = new JsonResult {Data = json, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
            return result;
        }
    }
}