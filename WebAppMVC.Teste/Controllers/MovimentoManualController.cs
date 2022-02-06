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
    public class MovimentoManualController : Controller
    {
        private BaseTesteEntities db = new BaseTesteEntities();

        // GET: MovimentoManual
        public ActionResult Index()
        {
            var mOVIMENTO_MANUAL = db.MOVIMENTO_MANUAL.Include(m => m.PRODUTO_COSIF);
            return View(mOVIMENTO_MANUAL.ToList());
        }

        // GET: MovimentoManual/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMENTO_MANUAL mOVIMENTO_MANUAL = db.MOVIMENTO_MANUAL.Find(id);
            if (mOVIMENTO_MANUAL == null)
            {
                return HttpNotFound();
            }
            return View(mOVIMENTO_MANUAL);
        }

        // GET: MovimentoManual/Create
        public ActionResult Create()
        {
            ViewBag.COD_COSIF = new SelectList(db.PRODUTO_COSIF, "COD_COSIF", "COD_PRODUTO");
            return View();
        }

        // POST: MovimentoManual/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DAT_MES,DAT_ANO,NUM_LACAMENTO,COD_PRODUTO,COD_COSIF,DES_DESCRICAO,DAT_MOVIMENTO,COD_USUARIO,VAL_VALOR")] MOVIMENTO_MANUAL mOVIMENTO_MANUAL)
        {
            if (ModelState.IsValid)
            {
                db.MOVIMENTO_MANUAL.Add(mOVIMENTO_MANUAL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COD_COSIF = new SelectList(db.PRODUTO_COSIF, "COD_COSIF", "COD_PRODUTO", mOVIMENTO_MANUAL.COD_COSIF);
            return View(mOVIMENTO_MANUAL);
        }

        // GET: MovimentoManual/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMENTO_MANUAL mOVIMENTO_MANUAL = db.MOVIMENTO_MANUAL.Find(id);
            if (mOVIMENTO_MANUAL == null)
            {
                return HttpNotFound();
            }
            ViewBag.COD_COSIF = new SelectList(db.PRODUTO_COSIF, "COD_COSIF", "COD_PRODUTO", mOVIMENTO_MANUAL.COD_COSIF);
            return View(mOVIMENTO_MANUAL);
        }

        // POST: MovimentoManual/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DAT_MES,DAT_ANO,NUM_LACAMENTO,COD_PRODUTO,COD_COSIF,DES_DESCRICAO,DAT_MOVIMENTO,COD_USUARIO,VAL_VALOR")] MOVIMENTO_MANUAL mOVIMENTO_MANUAL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOVIMENTO_MANUAL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COD_COSIF = new SelectList(db.PRODUTO_COSIF, "COD_COSIF", "COD_PRODUTO", mOVIMENTO_MANUAL.COD_COSIF);
            return View(mOVIMENTO_MANUAL);
        }

        // GET: MovimentoManual/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIMENTO_MANUAL mOVIMENTO_MANUAL = db.MOVIMENTO_MANUAL.Find(id);
            if (mOVIMENTO_MANUAL == null)
            {
                return HttpNotFound();
            }
            return View(mOVIMENTO_MANUAL);
        }

        // POST: MovimentoManual/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MOVIMENTO_MANUAL mOVIMENTO_MANUAL = db.MOVIMENTO_MANUAL.Find(id);
            db.MOVIMENTO_MANUAL.Remove(mOVIMENTO_MANUAL);
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
