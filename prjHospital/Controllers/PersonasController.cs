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
    public class PersonasController : Controller
    {
        private HospitalContext db = new HospitalContext();

        // GET: Personas
        public ActionResult Index()
        {
            return View(db.Personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonaModel personaModel = db.Personas.Find(id);
            if (personaModel == null)
            {
                return HttpNotFound();
            }
            return View(personaModel);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "Nombre");
            return View();
        }

        // POST: Personas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombres,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,CedulaIdentidad,SexoId")] PersonaModel personaModel)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(personaModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "Nombre", personaModel.SexoId);
            return View(personaModel);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonaModel personaModel = db.Personas.Find(id);
            if (personaModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "Nombre", personaModel.SexoId);
            return View(personaModel);
        }

        // POST: Personas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombres,ApellidoPaterno,ApellidoMaterno,FechaNacimiento,CedulaIdentidad,SexoId")] PersonaModel personaModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personaModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SexoId = new SelectList(db.Sexos, "Id", "Nombre", personaModel.SexoId);

            return View(personaModel);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonaModel personaModel = db.Personas.Find(id);
            if (personaModel == null)
            {
                return HttpNotFound();
            }
            return View(personaModel);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonaModel personaModel = db.Personas.Find(id);
            db.Personas.Remove(personaModel);
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
