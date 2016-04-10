using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;
using EgelTraining.WebUI.Models;


namespace EgelTraining.WebUI.Controllers
{
    public class ExamenController : Controller
    {
        private IExamenRepository repository;
        public int PageSize = 4;


        public ExamenController(IExamenRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1)
        {
            ExamenesListViewModel model = new ExamenesListViewModel
            {
                Examenes = repository.Examenes.OrderBy(e => e.IDExamen).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = repository.Examenes.Count() }
            };
            return View(model);
        }

    }
}