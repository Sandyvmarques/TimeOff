using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeOff.Models;

namespace TimeOff.Controllers
{
    public class RealizadorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Realizadors
        public ActionResult Index()
        {
            return View(db.Realizador.ToList());
        }

        // GET: Realizadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizador realizador = db.Realizador.Find(id);
            if (realizador == null)
            {
                return HttpNotFound();
            }
            return View(realizador);
        }

        // GET: Realizadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Realizadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataNasc,Biografia")] Realizador realizador)
        {
            if (ModelState.IsValid)
            {
                db.Realizador.Add(realizador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(realizador);
        }

        // GET: Realizadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizador realizador = db.Realizador.Find(id);
            if (realizador == null)
            {
                return HttpNotFound();
            }
            return View(realizador);
        }

        // POST: Realizadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataNasc,Biografia")] Realizador realizador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realizador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(realizador);
        }

        // GET: Realizadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realizador realizador = db.Realizador.Find(id);
            if (realizador == null)
            {
                return HttpNotFound();
            }
            return View(realizador);
        }

        // POST: Realizadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Realizador realizador = db.Realizador.Find(id);
            db.Realizador.Remove(realizador);
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
