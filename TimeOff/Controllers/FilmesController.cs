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
            ViewBag.Atores = new SelectList(db.Ators, "Id", "Nome");
            return View();
        }

        // POST: Filmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Titulo,Sinopse,AnoLanc,LinkTrailer,ImagensFilme,RealizadorId")]
        Filme filme, HttpPostedFileBase ImagensFilme, List<int> Categorias, List<int> Atores)
        {
            if (ImagensFilme != null)
            {
                filme.ImagensFilme = Path.GetExtension(ImagensFilme.FileName);
            }

            if (Atores == null )
            {
                Atores= new List<int>();
            }
            else if( Categorias == null)
            {
                Categorias = new List<int>();
            }else
            if (ModelState.IsValid)
            {
                db.Filme.Add(filme);
                //Adicionar categorias aos filmes
                IQueryable<Categorias> temp2 = db.Categorias.Where(a => Categorias.Any(aa => a.Id == aa));
                filme.Categorias = temp2.ToList();

                //lista dos atores 
                IQueryable<Ator> temp3 = db.Ators.Where(a => Atores.Any(aa => a.Id == aa));
                filme.Atores = temp3.ToList();
                db.SaveChanges();

                //Adiciona uma imagem ao Filme
                ImagensFilme.SaveAs(Path.Combine(Server.MapPath("~/Imagens/" + filme.Id + filme.ImagensFilme)));
                return RedirectToAction("Index");
            }
            //Adicionar Realizador 
            ViewBag.sel_Categorias = Categorias.ToList();
            ViewBag.sel_Atores = Atores.ToList();
            ViewBag.Categorias = new SelectList(db.Categorias, "Id", "Nome");
            ViewBag.Atores = new SelectList(db.Ators, "Id", "Nome");
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
            ViewBag.Categorias = new SelectList(db.Categorias, "Id", "Nome");
            ViewBag.sel_Categorias = filme.Categorias.Select(i => i.Id).ToList();
            ViewBag.Atores = new SelectList(db.Ators, "Id", "Nome");
            ViewBag.sel_Atores = filme.Atores.Select(i => i.Id).ToList();
            return View(filme);
        }

        // POST: Filmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Sinopse,AnoLanc,LinkTrailer,ImagensFilme,RealizadorId")]
        Filme filme, HttpPostedFileBase ImagemFilme, List<int> Categorias, List<int> Atores)
        {
            if (Atores == null)
            {
                Atores = new List<int>();
            }
            else if (Categorias == null)
            {
                Categorias = new List<int>();
            }
            else
            if (ModelState.IsValid)
            {
                //lista das categorias dos filmes para Editar 
                //filme.Categorias.Clear();
                IQueryable<Categorias> temp2 = db.Categorias.Where(a => Categorias.Any(aa => a.Id == aa));
                filme.Categorias = temp2.ToList();


                //lista dos atores 
                //filme.Atores.Clear();
                IQueryable<Ator> temp3 = db.Ators.Where(a => Atores.Any(aa => a.Id == aa));
                filme.Atores = temp3.ToList();
                db.Entry(filme).State = EntityState.Modified;

                //Escolher imagem dos Filmes
                if (ImagemFilme != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/Imagens/" + filme.Id + filme.ImagensFilme)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/Imagens/" + filme.Id + filme.ImagensFilme));
                    }
                    filme.ImagensFilme = Path.GetExtension(ImagemFilme.FileName);
                    ImagemFilme.SaveAs(Path.Combine(Server.MapPath("~/Imagens/" + filme.Id + filme.ImagensFilme)));
                    
                }

                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.RealizadorId = new SelectList(db.Realizador, "Id", "NomeRealizador", filme.RealizadorId);
            ViewBag.Categorias = new SelectList(db.Categorias, "Id", "Nome");
            ViewBag.sel_Categorias = Categorias.ToList();
            ViewBag.Atores = new SelectList(db.Ators, "Id", "Nome");
            ViewBag.sel_Atores = Atores.ToList();
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
            filme.Atores.Clear();
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
