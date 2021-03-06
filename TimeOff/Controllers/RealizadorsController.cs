﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
        [Authorize(Roles = "Admin")] //dá permições ao Admin para Criar novos Realizadores 
        public ActionResult Create()
        {
            return View();
        }

        // POST: Realizadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,NomeRealizador,DataNasc,Biografia,ImagemRealizador")] Realizador realizador, HttpPostedFileBase ImagemRealizadr)
        {
            if (ImagemRealizadr != null)
            {
                realizador.ImagemRealizador = Path.GetExtension(ImagemRealizadr.FileName);
            }
            if (ModelState.IsValid)
            {
                db.Realizador.Add(realizador);
                db.SaveChanges();
                //A Imagem irá de ter o nome do Id do Realizador 
                ImagemRealizadr.SaveAs(Path.Combine(Server.MapPath("~/ImagensRealizador/" + realizador.Id + realizador.ImagemRealizador)));

                return RedirectToAction("Index");
            }

            return View(realizador);
        }

        // GET: Realizadors/Edit/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,NomeRealizador,DataNasc,Biografia,ImagemRealizador")] Realizador realizador, HttpPostedFileBase ImagemRealizadr)
        {
            if (ModelState.IsValid)
            {   //Se adicionar outra foto irá apagar a antiga e adicionar a nova adicionada
                if (ImagemRealizadr != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/ImagensRealizador/" + realizador.Id + realizador.ImagemRealizador)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/ImagensRealizador/" + realizador.Id + realizador.ImagemRealizador));
                    }
                    realizador.ImagemRealizador = Path.GetExtension(ImagemRealizadr.FileName);
                    db.Entry(realizador).State = EntityState.Modified;
                    ImagemRealizadr.SaveAs(Path.Combine(Server.MapPath("~/ImagensRealizador/" + realizador.Id + realizador.ImagemRealizador)));

                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(realizador);
        }

        // GET: Realizadors/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
