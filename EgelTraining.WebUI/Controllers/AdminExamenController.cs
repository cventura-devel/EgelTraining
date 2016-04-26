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

        //si queiren correr el equivalente de la línea repository.Examenes.FirstOrDefault(c => c.IDExamen == IDExamen); descomentar el método opcion2 y donde se le
        //llama, así como comentar la línea Examan examen = repository.Examenes.FirstOrDefault(c => c.IDExamen == IDExamen);

        //private Examan opcion2(int IDExamen)
        //{
        //    var examen = from rep in repository.Examenes
        //                 where rep.IDExamen == IDExamen
        //                 select rep;

        //    return examen.FirstOrDefault(); 
        //}

        public ViewResult Edit(int IDExamen)
        {
            Examan examen = repository.Examenes.FirstOrDefault(c => c.IDExamen == IDExamen);
            //Examan examen = opcion2(IDExamen);

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