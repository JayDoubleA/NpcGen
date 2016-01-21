﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using NpcGen.DataAccess;
using NpcGen.Models.NpcModels;

namespace NpcGen.Controllers
{
    public class ClassModelsController : Controller
    {
        private NpcContext _context = new NpcContext();

        // GET: ClassModels
        public ActionResult Index()
        {
            return View(_context.Classes.ToList());
        }

        // GET: ClassModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassModel classModel = _context.Classes.Find(id);
            if (classModel == null)
            {
                return HttpNotFound();
            }
            return View(classModel);
        }

        // GET: ClassModels/Create
        public ActionResult Create()
        {
            GetClassAbilities();
           
            return View();
        }

        // POST: ClassModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,HitDieType,Level,ProficencyBonus,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma,HitPoints,Movement,BaseArmourClass,Possessions,Xp")] ClassModel classModel)
        {
            if (ModelState.IsValid)
            {
                _context.Classes.Add(classModel);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            GetClassAbilities();
            GetClassAbilitiesSelected(classModel);

            return View(classModel);
        }

        // GET: ClassModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassModel classModel = _context.Classes.Find(id);
            if (classModel == null)
            {
                return HttpNotFound();
            }

            GetClassAbilities();
            GetClassAbilitiesSelected(classModel);

            return View(classModel);
        }

        // POST: ClassModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(
                Include =
                    "Id,Name,HitDieType,Level,ProficencyBonus,Strength,Dexterity,Constitution,Intelligence,Wisdom,Charisma,HitPoints,Movement,BaseArmourClass,Possessions,Xp"
                )] ClassModel classModel, List<string> classAbilities)
        {
            GetClassAbilities();

            if (ModelState.IsValid)
            {
                var classAbilityModels =
                    ((List<ClassAbilityModel>) ViewBag.ClassAbilities).Where(
                        x => classAbilities.Contains(x.Id.ToString())).ToList();

                foreach (var abi in classAbilityModels)
                {
                    abi.Classes.Add(classModel);
                }

                _context.SaveChanges();

                var dbModel = _context.Classes.SingleOrDefault(x => x.Name.Equals(classModel.Name) && !x.Id.Equals(classModel.Id));
                _context.Classes.Remove(dbModel);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            GetClassAbilitiesSelected(classModel);

            return View(classModel);
        }

        // GET: ClassModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassModel classModel = _context.Classes.Find(id);
            if (classModel == null)
            {
                return HttpNotFound();
            }
            return View(classModel);
        }

        // POST: ClassModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassModel classModel = _context.Classes.Find(id);
            _context.Classes.Remove(classModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        private void GetClassAbilities()
        {
            ViewBag.ClassAbilities = _context.ClassAbilities.OrderBy(x => x.Name).ToList();
        }

        private void GetClassAbilitiesSelected(ClassModel classModel)
        {
            ViewBag.ClassAbilitiesSelectedId = classModel.ClassAbilities.Select(x => x.Id).ToList();
        }

        public ClassModel GetClassById(int id)
        {
            return _context.Classes.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
