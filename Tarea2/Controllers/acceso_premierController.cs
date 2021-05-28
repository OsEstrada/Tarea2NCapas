using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tarea2.Models;

namespace Tarea2.Controllers
{
    public class acceso_premierController : Controller
    {
        private premierEntities db = new premierEntities();

        // GET: acceso_premier
        public ActionResult Index()
        {
            var acceso_premier = db.acceso_premier.Include(a => a.persona).Include(a => a.pelicula);
            return View(acceso_premier.ToList());
        }

        // GET: acceso_premier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acceso_premier acceso_premier = db.acceso_premier.Find(id);
            if (acceso_premier == null)
            {
                return HttpNotFound();
            }
            return View(acceso_premier);
        }

        // GET: acceso_premier/Create
        public ActionResult Create()
        {
            ViewBag.idpersona = new SelectList(db.persona, "idpersona", "nombre");
            //Aca se realizo un cambio, esto mostraba la clasificacion en lugar del nombre de la pelicula, de modo que se cambio para si muestre el nombre
            ViewBag.nombre_pelicula = new SelectList(db.pelicula, "nombre", "nombre");
            return View();
        }

        // POST: acceso_premier/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idapremier,nombre_pelicula,idpersona")] acceso_premier acceso_premier)
        {
            if (ModelState.IsValid)
            {
                db.acceso_premier.Add(acceso_premier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idpersona = new SelectList(db.persona, "idpersona", "nombre", acceso_premier.idpersona);
            //Aca se realizo un cambio, esto mostraba la clasificacion en lugar del nombre de la pelicula, de modo que se cambio para si muestre el nombre
            ViewBag.nombre_pelicula = new SelectList(db.pelicula, "nombre", "nombre", acceso_premier.nombre_pelicula);
            return View(acceso_premier);
        }

        // GET: acceso_premier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acceso_premier acceso_premier = db.acceso_premier.Find(id);
            if (acceso_premier == null)
            {
                return HttpNotFound();
            }
            ViewBag.idpersona = new SelectList(db.persona, "idpersona", "nombre", acceso_premier.idpersona);
            //Aca se realizo un cambio, esto mostraba la clasificacion en lugar del nombre de la pelicula, de modo que se cambio para si muestre el nombre
            ViewBag.nombre_pelicula = new SelectList(db.pelicula, "nombre", "nombre", acceso_premier.nombre_pelicula);
            return View(acceso_premier);
        }

        // POST: acceso_premier/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idapremier,nombre_pelicula,idpersona")] acceso_premier acceso_premier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acceso_premier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idpersona = new SelectList(db.persona, "idpersona", "nombre", acceso_premier.idpersona);
            //Aca se realizo un cambio, esto mostraba la clasificacion en lugar del nombre de la pelicula, de modo que se cambio para si muestre el nombre
            ViewBag.nombre_pelicula = new SelectList(db.pelicula, "nombre", "nombre", acceso_premier.nombre_pelicula);
            return View(acceso_premier);
        }

        // GET: acceso_premier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            acceso_premier acceso_premier = db.acceso_premier.Find(id);
            if (acceso_premier == null)
            {
                return HttpNotFound();
            }
            return View(acceso_premier);
        }

        // POST: acceso_premier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            acceso_premier acceso_premier = db.acceso_premier.Find(id);
            db.acceso_premier.Remove(acceso_premier);
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
