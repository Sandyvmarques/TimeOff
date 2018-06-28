using System;
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
    public class FilmesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Filmes
        public ActionResult Index()
        {
            var filme = db.Filme.Include(f => f.Realizadores);
            return View(filme.ToList());
        }

        // GET: Filmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filme.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // GET: Filmes/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.RealizadorId = new SelectList(db.Realizador, "Id", "NomeRealizador");
            ViewBag.Categorias = new SelectList(db.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Titulo,Sinopse,AnoLanc,LinkTrailer,ImagensFilme,RealizadorId")]
        Filme filme, HttpPostedFileBase ImagensFilme, List<int> Categorias, List<int> ator)
        {
            if (ImagensFilme != null)
            {
                filme.ImagensFilme = ImagensFilme.FileName;
            }
            if (ModelState.IsValid)
            {
                db.Filme.Add(filme);
                //Adicionar categorias aos filmes
                IQueryable<Categorias> temp2 = db.Categorias.Where(a => Categorias.Any(aa => a.Id == aa));
                filme.Categorias = temp2.ToList();
                db.SaveChanges();

                //lista dos atores 
                IQueryable<Ator> temp3 = db.Ators.Where(a => ator.Any(aa => a.Id == aa));
                filme.Atores = temp3.ToList();

                db.SaveChanges();

                //Adiciona uma imagem ao Filme
                ImagensFilme.SaveAs(Path.Combine(Server.MapPath("~/Imagens/" + ImagensFilme.FileName)));
                return RedirectToAction("Index");
            }
            //Adicionar Realizador 
            ViewBag.RealizadorId = new SelectList(db.Realizador, "Id", "NomeRealizador", filme.RealizadorId);
            return View(filme);
        }

        // GET: Filmes/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filme.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            ViewBag.RealizadorId = new SelectList(db.Realizador, "Id", "NomeRealizador", filme.RealizadorId);
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Sinopse,AnoLanc,LinkTrailer,ImagensFilme,RealizadorId")]
        Filme filme, HttpPostedFileBase ImagensFilme, List<int> Categorias, List<int> ator)
        {
            if (ModelState.IsValid)
            {
                db.Filme.Add(filme);
                //lista das categorias dos filmes para Editar 

                /*IQueryable<Categorias> temp2 = db.Categorias.Where(a => Categorias.Any(aa => a.Id == aa));
                filme.Categorias = temp2.ToList();*/

                db.SaveChanges();

                //lista dos atores 
                /*IQueryable<Ator> temp3 = db.Ators.Where(a => ator.Any(aa => a.Id == aa));
                filme.Atores = temp3.ToList();*/

                db.SaveChanges();
                //Escolher imagem dos Filmes
                //ImagensFilme.SaveAs(Path.Combine(Server.MapPath("~/Imagens/" + ImagensFilme.FileName)));
                return RedirectToAction("Index");

            }
            ViewBag.RealizadorId = new SelectList(db.Realizador, "Id", "NomeRealizador", filme.RealizadorId);
            ViewBag.RealizadorId = new SelectList(db.Realizador, "Id", "NomeRealizador", filme.RealizadorId);


            return View(filme);
        }

        // GET: Filmes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filme filme = db.Filme.Find(id);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(filme);
        }

        // POST: Filmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Filme filme = db.Filme.Find(id);
            filme.Categorias.Clear();
            db.Filme.Remove(filme);
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
        //página com informações sobre mim 
        public ActionResult Sobre()
        {
            return View();
        }
    }
}
