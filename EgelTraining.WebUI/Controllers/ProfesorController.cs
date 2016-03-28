using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EgelTraining.Domain.Abstract;

namespace EgelTraining.WebUI.Controllers
{
    public class ProfesorController : Controller
    {

        private IProfesorRepository repository;


        public ProfesorController(IProfesorRepository profesorRepository)
        {
            repository = profesorRepository;
        }

        public ViewResult List()
        {
            return View(repository);
        }

    }
}