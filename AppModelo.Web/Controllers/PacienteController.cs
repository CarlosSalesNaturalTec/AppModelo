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
        public ActionResult Index(IEnumerable<Paciente> obj)
        {
            return View(obj);
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Paciente obj = service.GetByID(id);
            if (obj == null)
            {
                ViewBag.id = id;
                return View("NotFound");
            }
            return View(obj);
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
        public ActionResult Create(Paciente obj)
        {
            if (ModelState.IsValid)
            {
                service.Create(obj);
                return RedirectToAction("Search");
            }
            return View(obj);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Paciente obj = service.GetByID(id);
            if (obj == null)
            {
                ViewBag.id = id;
                return View("NotFound");
            }
            return View(obj);
        }

        // POST: Paciente/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente obj)
        {
            if (ModelState.IsValid)
            {
                service.Edit(obj);
                return RedirectToAction("Search");
            }
            return View(obj);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Paciente obj = service.GetByID(id);
            if (obj == null)
            {
                ViewBag.id = id;
                return View("NotFound");
            }
            return View(obj);
        }

        // POST: Paciente/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Paciente obj = service.GetByID(id);
            service.Delete(obj);
            return RedirectToAction("Search");
        }

    }
}
