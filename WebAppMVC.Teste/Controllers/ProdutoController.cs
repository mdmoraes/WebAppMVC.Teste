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
    public class ProdutoController : Controller
    {
        private BaseTesteEntities db = new BaseTesteEntities();

        // GET: Produto
        public ActionResult Index()
        {
            return View(db.PRODUTO.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUTO pRODUTO = db.PRODUTO.Find(id);
            if (pRODUTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUTO);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "COD_PRODUTO,DES_PRODUTO,STA_STATUS")] PRODUTO pRODUTO)
        {
            if (ModelState.IsValid)
            {
                db.PRODUTO.Add(pRODUTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRODUTO);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUTO pRODUTO = db.PRODUTO.Find(id);
            if (pRODUTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUTO);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "COD_PRODUTO,DES_PRODUTO,STA_STATUS")] PRODUTO pRODUTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRODUTO);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUTO pRODUTO = db.PRODUTO.Find(id);
            if (pRODUTO == null)
            {
                return HttpNotFound();
            }
            return View(pRODUTO);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUTO pRODUTO = db.PRODUTO.Find(id);
            db.PRODUTO.Remove(pRODUTO);
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
