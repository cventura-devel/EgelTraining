using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;


namespace EgelTraining.WebUI.Controllers
{
    public class PlanEstudioController : Controller
    {
        private IPlanRepository repository;

        public PlanEstudioController(IPlanRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View(repository.Planes);
        }


        public ViewResult Edit(string siglas,string plan)
        {
            PlanEstudio planEstudio = repository.Planes.FirstOrDefault(c => c.Siglas == siglas && c.Plan == plan);
            return View(planEstudio);
        }

        [HttpPost]
        public ActionResult Edit(PlanEstudio planEstudio)
        {
            if (ModelState.IsValid)
            {
                repository.SavePlan(planEstudio);
                TempData["message"] = string.Format("{0} salvado correctamente", planEstudio.Plan);
                return RedirectToAction("Index");
            }
            else
            {
                return View(planEstudio);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new PlanEstudio());
        }


        [HttpPost]
        public ActionResult Delete(string siglas,string plan)
        {
            PlanEstudio deletedPlan = repository.DeletePlan(siglas,plan);
            if (deletedPlan != null)
            {
                TempData["message"] = string.Format("Plan {0} de {1} fue borrado", deletedPlan.Plan,deletedPlan.Siglas);
            }
            return RedirectToAction("Index");
        }
    }
}