using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;
using EgelTraining.WebUI.Models;
using System.Collections.Generic;

namespace EgelTraining.WebUI.Controllers
{
    public class AdminAlumnoController : Controller
    {

        private IAlumnoRepository repositoryA;
        private ICarreraRepository repositoryC;

        public AdminAlumnoController(IAlumnoRepository repoA, ICarreraRepository repoC)
        {
            repositoryA = repoA;
            repositoryC = repoC;
        }

        public ViewResult Index()
        {
            //aqui es donde entra la magia
            AlumnosViewModel model = new AlumnosViewModel
            {
                Alumnos = repositoryA.Alumnos
            };

            return View(model.Alumnos);
        }


        public ViewResult Edit(string matricula)
        {
            Alumno alumno = repositoryA.Alumnos.First(a => a.Matricula == matricula);
            PopulateCarrerasDropDownList(alumno.Carrera);
            return View(alumno);
        }


        private void PopulateCarrerasDropDownList(object selectedCarrera = null)
        {
            var carrerasQuery = repositoryC.Carreras;
            ViewBag.siglasCarrera = new SelectList(carrerasQuery, "Siglas", "NombreLargo", selectedCarrera);
        }


        [HttpPost]
        public ActionResult Edit(Alumno alumno)
        {
            if(ModelState.IsValid)
            {
                if (TryUpdateModel(alumno,"", new string[] { "Matricula", "Nombre", "ApellidoPaterno", "ApellidoMaterno", "Carrera" }))
                {
                    repositoryA.SaveAlumno(alumno);
                    TempData["message"] = string.Format("{0} salvado correctamente", alumno.Matricula);
                }
                else
                {
                    TempData["message"] = string.Format("{0} no fue salvado, error en la base de datos", alumno.Matricula);
                }

                return RedirectToAction("Index");

            }
            else
            {
                return View(alumno);
            }
        }


   
        public ViewResult Create()
        {
            PopulateCarrerasDropDownList();
            return View("Edit", new Alumno());
        }


        [HttpPost]
        public ActionResult Delete(string matricula)
        {
            Alumno deletedAlumno = repositoryA.DeleteAlumno(matricula);
            if (deletedAlumno != null)
            {
                TempData["message"] = string.Format("{0} fue borrado exitósamente", deletedAlumno.Nombre);
            }
            return RedirectToAction("Index");
        }
    }
}