using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;


namespace EgelTraining.WebUI.Controllers
{
    public class AdminTemaController : Controller
    {

        ITemaRepository repository;

        public AdminTemaController(ITemaRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Temas);
        }

        public ViewResult Edit(string claveTema)
        {
            Tema tema = repository.Temas.FirstOrDefault(c => c.ClaveTema == claveTema);

            return View(tema);
        }

        [HttpPost]
        public ActionResult Edit(Tema tema)
        {
            if (ModelState.IsValid)
            {
                repository.SaveTema(tema);
                TempData["message"] = string.Format("{0} salvado correctamente", tema.NombreTema);
                return RedirectToAction("Index");
            }
            else
            {
                return View(tema);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Tema());
        }

        [HttpPost]
        public ActionResult Delete(string claveTema)
        {
            Tema deletedTema = repository.DeleteTema(claveTema);
            if (deletedTema != null)
            {
                TempData["message"] = string.Format("{0} fue borrado exitósamente", deletedTema.NombreTema);
            }
            return RedirectToAction("Index");
        }
    }
}