using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppModelo.Services.Models;

namespace AppModelo.Web.Controllers
{
    public class ConsultasController : Controller
    {
        private AppModeloEntities db = new AppModeloEntities();

        // GET: Consultas
        public ActionResult Index()
        {
            var consultas = db.Consultas.Include(c => c.Especialidade).Include(c => c.Paciente);
            return View(consultas.ToList());
        }

        // GET: Consultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultas consultas = db.Consultas.Find(id);
            if (consultas == null)
            {
                return HttpNotFound();
            }
            return View(consultas);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            ViewBag.especialidadeID = new SelectList(db.Especialidade, "Id", "Nome");
            ViewBag.pacienteID = new SelectList(db.Paciente, "Id", "Nome");
            return View();
        }

        // POST: Consultas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,pacienteID,especialidadeID,dataConsulta")] Consultas consultas)
        {
            if (ModelState.IsValid)
            {
                db.Consultas.Add(consultas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.especialidadeID = new SelectList(db.Especialidade, "Id", "Nome", consultas.especialidadeID);
            ViewBag.pacienteID = new SelectList(db.Paciente, "Id", "Nome", consultas.pacienteID);
            return View(consultas);
        }

        // GET: Consultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultas consultas = db.Consultas.Find(id);
            if (consultas == null)
            {
                return HttpNotFound();
            }
            ViewBag.especialidadeID = new SelectList(db.Especialidade, "Id", "Nome", consultas.especialidadeID);
            ViewBag.pacienteID = new SelectList(db.Paciente, "Id", "Nome", consultas.pacienteID);
            return View(consultas);
        }

        // POST: Consultas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,pacienteID,especialidadeID,dataConsulta")] Consultas consultas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.especialidadeID = new SelectList(db.Especialidade, "Id", "Nome", consultas.especialidadeID);
            ViewBag.pacienteID = new SelectList(db.Paciente, "Id", "Nome", consultas.pacienteID);
            return View(consultas);
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultas consultas = db.Consultas.Find(id);
            if (consultas == null)
            {
                return HttpNotFound();
            }
            return View(consultas);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultas consultas = db.Consultas.Find(id);
            db.Consultas.Remove(consultas);
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
