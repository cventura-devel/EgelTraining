using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using EgelTraining.Domain.Concrete;
using EgelTraining.WebUI.Models;


namespace EgelTraining.WebUI.Controllers
{
    public class RespondeExamenController : Controller
    {
        private IPreguntaRepository repository;
        public int pageSize = 10;

        public RespondeExamenController(IPreguntaRepository repo)
        {
            repository = repo;
        }



        public ViewResult List(int page = 1)
        {
            ContestaExamenViewModel model = new ContestaExamenViewModel
            {
                Preguntas = repository.Preguntas.OrderBy(p => p.IDPregunta).Skip((page - 1) * pageSize).Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Preguntas.Count()
                }
            };

            return View(model);
        }

        // GET: RespondeExamen
        public ActionResult Index()
        {
            return View();
        }
    }
}