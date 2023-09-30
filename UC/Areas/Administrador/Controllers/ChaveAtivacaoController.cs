using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UC.Models;

namespace UC.Areas.Administrador.Controllers
{
    public class ChaveAtivacaoController : Controller
    {
        private UCDBContext db = new UCDBContext();

        // GET: Administrador/ChaveAtivacao
        public ActionResult Index()
        {
            var chaveAtivacaos = db.ChaveAtivacaos.Include(c => c.Usuario);
            return View(chaveAtivacaos.ToList());
        }

        // GET: Administrador/ChaveAtivacao/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChaveAtivacao chaveAtivacao = db.ChaveAtivacaos.Find(id);
            if (chaveAtivacao == null)
            {
                return HttpNotFound();
            }
            return View(chaveAtivacao);
        }

        // GET: Administrador/ChaveAtivacao/Create
        public ActionResult Create()
        {
            ViewBag.usuarioUID = new SelectList(db.Usuarios, "usuarioUID", "cpf");
            return View();
        }

        // POST: Administrador/ChaveAtivacao/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "chaveAtivacaoUID,dataCriacao,cpf,tipoPermissao,email,usuarioUID")] ChaveAtivacao chaveAtivacao)
        {
            if (ModelState.IsValid)
            {
                db.ChaveAtivacaos.Add(chaveAtivacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usuarioUID = new SelectList(db.Usuarios, "usuarioUID", "cpf", chaveAtivacao.usuarioUID);
            return View(chaveAtivacao);
        }

        // GET: Administrador/ChaveAtivacao/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChaveAtivacao chaveAtivacao = db.ChaveAtivacaos.Find(id);
            if (chaveAtivacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.usuarioUID = new SelectList(db.Usuarios, "usuarioUID", "cpf", chaveAtivacao.usuarioUID);
            return View(chaveAtivacao);
        }

        // POST: Administrador/ChaveAtivacao/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "chaveAtivacaoUID,dataCriacao,cpf,tipoPermissao,email,usuarioUID")] ChaveAtivacao chaveAtivacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chaveAtivacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usuarioUID = new SelectList(db.Usuarios, "usuarioUID", "cpf", chaveAtivacao.usuarioUID);
            return View(chaveAtivacao);
        }

        // GET: Administrador/ChaveAtivacao/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChaveAtivacao chaveAtivacao = db.ChaveAtivacaos.Find(id);
            if (chaveAtivacao == null)
            {
                return HttpNotFound();
            }
            return View(chaveAtivacao);
        }

        // POST: Administrador/ChaveAtivacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ChaveAtivacao chaveAtivacao = db.ChaveAtivacaos.Find(id);
            db.ChaveAtivacaos.Remove(chaveAtivacao);
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
