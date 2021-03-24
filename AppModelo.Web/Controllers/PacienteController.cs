using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using AppModelo.Services.AppService;
using AppModelo.Services.Models;
using AppModelo.Web.Models;

namespace AppModelo.Web.Controllers
{
    public class PacienteController : Controller
    {
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
                if (viewModel.Nome != null)
                    return View("Index", service.GetAllByNome(viewModel.Nome));
                
                if (viewModel.CartaoSUS != null)
                    return View("Index", service.GetAllByCartaoSUS(viewModel.CartaoSUS));
            }
            return View(viewModel);
        }

        public ActionResult SearchAll()
        {
            return View("Index", service.GetAll());
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
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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
                service.Create(paciente);
                return RedirectToAction("Search");
            }
            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Paciente paciente = service.GetByID(id);
            if (paciente == null)
            {
                ViewBag.id = id;
                return View("NotFound");
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
                service.Edit(paciente);
                return RedirectToAction("Search");
            }
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Paciente paciente = service.GetByID(id);
            if (paciente == null)
            {
                ViewBag.id = id;
                return View("NotFound");
            }
            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = service.GetByID(id);
            service.Delete(paciente);
            return RedirectToAction("Search");
        }

    }
}
