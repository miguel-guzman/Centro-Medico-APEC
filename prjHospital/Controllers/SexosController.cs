using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prjHospital.Data;
using prjHospital.Models;

namespace prjHospital.Controllers
{
    public class SexosController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: Sexos
        public ActionResult Index()
        {
            return View(db.Sexos.ToList());
        }

        // GET: Sexos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SexoModel sexoModel = db.Sexos.Find(id);
            if (sexoModel == null)
            {
                return HttpNotFound();
            }
            return View(sexoModel);
        }

        // GET: Sexos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sexos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] SexoModel sexoModel)
        {
            if (ModelState.IsValid)
            {
                db.Sexos.Add(sexoModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sexoModel);
        }

        // GET: Sexos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SexoModel sexoModel = db.Sexos.Find(id);
            if (sexoModel == null)
            {
                return HttpNotFound();
            }
            return View(sexoModel);
        }

        // POST: Sexos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] SexoModel sexoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sexoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sexoModel);
        }

        // GET: Sexos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SexoModel sexoModel = db.Sexos.Find(id);
            if (sexoModel == null)
            {
                return HttpNotFound();
            }
            return View(sexoModel);
        }

        // POST: Sexos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SexoModel sexoModel = db.Sexos.Find(id);
            db.Sexos.Remove(sexoModel);
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
