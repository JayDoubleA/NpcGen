using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NpcGen.DataAccess;
using NpcGen.Models.NpcModels;

namespace NpcGen.Controllers
{
    public class ClassAbilityModelsController : Controller
    {
        private NpcContext db = new NpcContext();

        // GET: ClassAbilityModels
        public ActionResult Index()
        {
            return View(db.ClassAbilities.ToList());
        }

        // GET: ClassAbilityModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAbilityModel classAbilityModel = db.ClassAbilities.Find(id);
            if (classAbilityModel == null)
            {
                return HttpNotFound();
            }
            return View(classAbilityModel);
        }

        // GET: ClassAbilityModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClassAbilityModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Level")] ClassAbilityModel classAbilityModel)
        {
            if (ModelState.IsValid)
            {
                db.ClassAbilities.Add(classAbilityModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classAbilityModel);
        }

        // GET: ClassAbilityModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAbilityModel classAbilityModel = db.ClassAbilities.Find(id);
            if (classAbilityModel == null)
            {
                return HttpNotFound();
            }
            return View(classAbilityModel);
        }

        // POST: ClassAbilityModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Level")] ClassAbilityModel classAbilityModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classAbilityModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classAbilityModel);
        }

        // GET: ClassAbilityModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassAbilityModel classAbilityModel = db.ClassAbilities.Find(id);
            if (classAbilityModel == null)
            {
                return HttpNotFound();
            }
            return View(classAbilityModel);
        }

        // POST: ClassAbilityModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassAbilityModel classAbilityModel = db.ClassAbilities.Find(id);
            db.ClassAbilities.Remove(classAbilityModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
