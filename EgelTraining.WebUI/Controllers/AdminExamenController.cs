using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;


namespace EgelTraining.WebUI.Controllers
{
    public class AdminExamenController : Controller
    {

        private IExamenRepository repository;

        public AdminExamenController(IExamenRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Examenes);
        }



        public ViewResult Edit(int IDExamen)
        {
            Examan examen = repository.Examenes.FirstOrDefault(c => c.IDExamen == IDExamen);
            return View(examen);
        }

        [HttpPost]
        public ActionResult Edit(Examan examen)
        {
            if (ModelState.IsValid)
            {
                repository.SaveExamen(examen);
                TempData["message"] = string.Format("{0} salvado correctamente", examen.Nombre);
                return RedirectToAction("Index");
            }
            else
            {
                return View(examen);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Examan());
        }

        [HttpPost]
        public ActionResult Delete(int IDExamen)
        {
            Examan deletedExamen = repository.DeleteExamen(IDExamen);
            if (deletedExamen != null)
            {
                TempData["message"] = string.Format("{0} fue borrado exitósamente", deletedExamen.Nombre);
            }
            return RedirectToAction("Index");
        }



    }
}