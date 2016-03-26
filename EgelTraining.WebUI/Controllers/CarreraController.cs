using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;

namespace EgelTraining.WebUI.Controllers
{
    public class CarreraController : Controller
    {
        private ICarreraRepository repository;
        
        public CarreraController(ICarreraRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Carreras);
        }

        public ViewResult Edit(string siglas)
        {
            Carrera carrera = repository.Carreras.FirstOrDefault(c => c.Siglas == siglas);
            return View(carrera);
        }

        [HttpPost]
        public ActionResult Edit(Carrera carrera)
        {
            if(ModelState.IsValid)
            {
                repository.SaveCarrera(carrera);
                TempData["message"] = string.Format("{0} salvado correctamente", carrera.NombreLargo);
                return RedirectToAction("Index");
            }
            else
            {
                return View(carrera);
            }
        }
        
    }
}