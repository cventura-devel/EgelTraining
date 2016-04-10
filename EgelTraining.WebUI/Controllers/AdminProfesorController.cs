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



    }
}