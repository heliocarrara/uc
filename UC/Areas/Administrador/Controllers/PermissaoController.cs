using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UC.Controllers;
using UC.Models;

namespace UC.Areas.Administrador.Controllers
{
    public class PermissaoController : BaseController
    {
        private UCDBContext db = new UCDBContext();

        // GET: Administrador/Permissao
        public ActionResult Index()
        {
            var permissaos = db.Permissaos.Include(p => p.ChaveAtivacao).Include(p => p.Usuario);
            return View(permissaos.ToList());
        }

        // GET: Administrador/Permissao/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissao permissao = db.Permissaos.Find(id);
            if (permissao == null)
            {
                return HttpNotFound();
            }
            return View(permissao);
        }

        // GET: Administrador/Permissao/Create
        public ActionResult Create()
        {
            ViewBag.chaveAtivacaoUID = new SelectList(db.ChaveAtivacaos, "chaveAtivacaoUID", "cpf");
            ViewBag.usuarioUID = new SelectList(db.Usuarios, "usuarioUID", "cpf");
            return View();
        }

        // POST: Administrador/Permissao/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "permissaoUID,ativo,dataCriacao,tipoPermissao,chaveAtivacaoUID,usuarioUID")] Permissao permissao)
        {
            if (ModelState.IsValid)
            {
                db.Permissaos.Add(permissao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.chaveAtivacaoUID = new SelectList(db.ChaveAtivacaos, "chaveAtivacaoUID", "cpf", permissao.chaveAtivacaoUID);
            ViewBag.usuarioUID = new SelectList(db.Usuarios, "usuarioUID", "cpf", permissao.usuarioUID);
            return View(permissao);
        }

        // GET: Administrador/Permissao/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissao permissao = db.Permissaos.Find(id);
            if (permissao == null)
            {
                return HttpNotFound();
            }
            ViewBag.chaveAtivacaoUID = new SelectList(db.ChaveAtivacaos, "chaveAtivacaoUID", "cpf", permissao.chaveAtivacaoUID);
            ViewBag.usuarioUID = new SelectList(db.Usuarios, "usuarioUID", "cpf", permissao.usuarioUID);
            return View(permissao);
        }

        // POST: Administrador/Permissao/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "permissaoUID,ativo,dataCriacao,tipoPermissao,chaveAtivacaoUID,usuarioUID")] Permissao permissao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permissao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.chaveAtivacaoUID = new SelectList(db.ChaveAtivacaos, "chaveAtivacaoUID", "cpf", permissao.chaveAtivacaoUID);
            ViewBag.usuarioUID = new SelectList(db.Usuarios, "usuarioUID", "cpf", permissao.usuarioUID);
            return View(permissao);
        }

        // GET: Administrador/Permissao/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permissao permissao = db.Permissaos.Find(id);
            if (permissao == null)
            {
                return HttpNotFound();
            }
            return View(permissao);
        }

        // POST: Administrador/Permissao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Permissao permissao = db.Permissaos.Find(id);
            db.Permissaos.Remove(permissao);
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
