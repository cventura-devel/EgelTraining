using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;

namespace EgelTraining.WebUI.Controllers
{
    public class AdminProfesorController : Controller
    {

        private IProfesorRepository repository;

        public AdminProfesorController(IProfesorRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Profesors);
        }

        public ViewResult Edit(string nomina)
        {
            Profesor profesor = repository.Profesors.FirstOrDefault(p => p.Nomina == nomina);
            return View(profesor);
        }

        [HttpPost]
        public ActionResult Edit(Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProfesor(profesor);
                TempData["message"] = string.Format("{0} salvado correctamente", profesor.Nomina);
                return RedirectToAction("Index");
            }
            else
            {
                return View(profesor);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Profesor());
        }


        [HttpPost]
        public ActionResult Delete(string nomina)
        {
            Profesor deletedProfesor = repository.DeleteProfesor(nomina);
            if(deletedProfesor != null)
            {
                TempData["message"] = string.Format("{0} fue borrado exitósamente", deletedProfesor.Nomina);
            }
            return RedirectToAction("Index");

        }
    }
}