using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;
using EgelTraining.WebUI.Models;

namespace EgelTraining.WebUI.Controllers
{
    public class ViewTemaPreguntaController : Controller
    {
        private ITemaRepository repository;
        
        public ViewTemaPreguntaController(ITemaRepository repo)
        {
            repository = repo;
        }

        public ViewResult index(string ClaveTema)
        {
            var ViewModel = new ViewTemaPregunta();
            ViewModel.Temas = repository.Temas;

            if (ClaveTema != null && ClaveTema != string.Empty)
            {
                ViewBag.ClaveTema = ClaveTema;
                ViewModel.Preguntas = repository.Temas.Where(i => i.ClaveTema == ClaveTema).Single().Preguntas;
            }
            return View(ViewModel);
        }

    }
}
