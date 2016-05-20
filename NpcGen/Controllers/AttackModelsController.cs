using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NpcGen.DataAccess;
using NpcGen.Models.NpcModels;

namespace NpcGen.Controllers
{
    public class AttackModelsController : Controller
    {
        private readonly NpcContext _context = new NpcContext();

        private List<AttackPropertyModel> AttackProperties { get; set; }
        private List<int> AttackPropertiesSelectedId { get; set; }

        // GET: AttackModels
        public ActionResult Index()
        {
            return View(_context.Attacks.ToList());
        }

        // GET: AttackModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttackModel attackModel = _context.Attacks.Find(id);
            if (attackModel == null)
            {
                return HttpNotFound();
            }
            return View(attackModel);
        }

        // GET: AttackModels/Create
        public ActionResult Create()
        {
            GetAttackProperties();
            ViewBagSet();
            return View();
        }

        // POST: AttackModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ToHit,Damage,Ability,DamageType")] AttackModel attackModel, List<string> attackProperties)
        {
            GetAttackProperties();

            if (ModelState.IsValid)
            {
                var attackPropModels = _context.AttackProperties.Where(x => attackProperties.Contains(x.Id.ToString())).ToList();
                attackModel.AttackProperties = attackPropModels;

                _context.Attacks.Add(attackModel);

                foreach (var mod in attackPropModels)
                {
                    mod.Attacks.Add(attackModel);
                }
               
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attackModel);
        }

        // GET: AttackModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttackModel attackModel = _context.Attacks.Find(id);
            if (attackModel == null)
            {
                return HttpNotFound();
            }
            return View(attackModel);
        }

        // POST: AttackModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ToHit,Damage,Ability,DamageType")] AttackModel attackModel)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(attackModel).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attackModel);
        }

        // GET: AttackModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttackModel attackModel = _context.Attacks.Find(id);
            if (attackModel == null)
            {
                return HttpNotFound();
            }
            return View(attackModel);
        }

        // POST: AttackModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttackModel attackModel = _context.Attacks.Find(id);
            _context.Attacks.Remove(attackModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private void GetAttackProperties()
        {
            AttackProperties = _context.AttackProperties.OrderBy(x => x.Name).ToList();
        }

        private void GetAttackPropertiesSelectedId(AttackModel attackModel)
        {
            AttackPropertiesSelectedId = attackModel.AttackProperties.Select(x => x.Id).ToList();
        }
        private void ViewBagSet()
        {
            ViewBag.AttackProperties = AttackProperties;
            ViewBag.AttackPropertiesSelectedId = AttackPropertiesSelectedId;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
