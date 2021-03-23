using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AppModelo.Services.AppService;
using AppModelo.Services.Models;
using AppModelo.Web.Models;

namespace AppModelo.Web.Controllers
{
    public class PacienteController : Controller
    {
        private AppModeloEntities db = new AppModeloEntities();
        private PacienteService service = new PacienteService();

        public ActionResult Search()
        {
            PacienteViewModel viewModel = new PacienteViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(PacienteViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                if (viewModel.ID > 0)
                {
                    IEnumerable<Paciente> pacientes = service.GetAllByID(viewModel.ID);
                    return View("Index", pacientes);
                }
                if (viewModel.Nome != null)
                {
                    IEnumerable<Paciente> pacientes = service.GetAllByNome(viewModel.Nome);
                    return View("Index", pacientes);
                }
                if (viewModel.CartaoSUS != null)
                {
                    IEnumerable<Paciente> pacientes = service.GetAllByCartaoSUS(viewModel.CartaoSUS);
                    return View("Index", pacientes);
                }
            }
            return View(viewModel);
        }

        public ActionResult SearchAll()
        {
            IEnumerable<Paciente> pacientes = service.GetAll();
            return View("Index", pacientes);
        }

        // GET: Paciente
        public ActionResult Index(IEnumerable<Paciente> pacientes)
        {
            return View(pacientes);
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Paciente paciente = service.GetByID(id);            
            if (paciente == null)
            {
                ViewBag.id = id;
                return View("NotFound");
            }
            return View(paciente);
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paciente/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,CartaoSUS")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Paciente.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Search");
            }

            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,CartaoSUS")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Search");
            }
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Paciente.Find(id);
            db.Paciente.Remove(paciente);
            db.SaveChanges();
            return RedirectToAction("Search");
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
