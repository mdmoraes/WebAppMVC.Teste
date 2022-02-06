using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Teste;

namespace WebAppMVC.Teste.Controllers
{
    public class ProdutoCosifController : Controller
    {
        private BaseTesteEntities db = new BaseTesteEntities();

        // GET: ProdutoCosif
        public ActionResult Index()
        {
            var pRODUTO_COSIF = db.PRODUTO_COSIF.Include(p => p.PRODUTO);
            return View(pRODUTO_COSIF.ToList());
        }

        // GET: ProdutoCosif/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUTO_COSIF pRODUTO_COSIF = db.PRODUTO_COSIF.Find(id);
            if (pRODUTO_COSIF == null)
            {
                return HttpNotFound();
            }
            return View(pRODUTO_COSIF);
        }

        // GET: ProdutoCosif/Create
        public ActionResult Create()
        {
            ViewBag.COD_PRODUTO = new SelectList(db.PRODUTO, "COD_PRODUTO", "DES_PRODUTO");
            return View();
        }

        // POST: ProdutoCosif/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_COSIF,COD_PRODUTO,COD_CLASSIFICACAO,STA_STATUS")] PRODUTO_COSIF pRODUTO_COSIF)
        {
            if (ModelState.IsValid)
            {
                db.PRODUTO_COSIF.Add(pRODUTO_COSIF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_PRODUTO = new SelectList(db.PRODUTO, "COD_PRODUTO", "DES_PRODUTO", pRODUTO_COSIF.COD_PRODUTO);
            return View(pRODUTO_COSIF);
        }

        // GET: ProdutoCosif/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUTO_COSIF pRODUTO_COSIF = db.PRODUTO_COSIF.Find(id);
            if (pRODUTO_COSIF == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_PRODUTO = new SelectList(db.PRODUTO, "COD_PRODUTO", "DES_PRODUTO", pRODUTO_COSIF.COD_PRODUTO);
            return View(pRODUTO_COSIF);
        }

        // POST: ProdutoCosif/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_COSIF,COD_PRODUTO,COD_CLASSIFICACAO,STA_STATUS")] PRODUTO_COSIF pRODUTO_COSIF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUTO_COSIF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_PRODUTO = new SelectList(db.PRODUTO, "COD_PRODUTO", "DES_PRODUTO", pRODUTO_COSIF.COD_PRODUTO);
            return View(pRODUTO_COSIF);
        }

        // GET: ProdutoCosif/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUTO_COSIF pRODUTO_COSIF = db.PRODUTO_COSIF.Find(id);
            if (pRODUTO_COSIF == null)
            {
                return HttpNotFound();
            }
            return View(pRODUTO_COSIF);
        }

        // POST: ProdutoCosif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUTO_COSIF pRODUTO_COSIF = db.PRODUTO_COSIF.Find(id);
            db.PRODUTO_COSIF.Remove(pRODUTO_COSIF);
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
