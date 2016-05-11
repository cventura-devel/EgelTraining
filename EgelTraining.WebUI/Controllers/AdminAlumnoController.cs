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
            //AlumnoCarreraViewModel model = new AlumnoCarreraViewModel
            //{
            Alumno alumno = repositoryA.Alumnos.First(a => a.Matricula == matricula);
            //Carreras = repositoryC.Carreras
            //};
            PopulateCarrerasDropDownList(alumno.Carrera);
            return View(alumno);
        }


        private void PopulateCarrerasDropDownList(object selectedCarrera = null)
        {
            var carrerasQuery = repositoryC.Carreras;
            ViewBag.siglasCarrera = new SelectList(carrerasQuery, "Siglas", "NombreLargo", selectedCarrera);
        }


        [HttpPost]
        public ActionResult Edit(Alumno alumno,string siglasCarrera)
        {
            if(ModelState.IsValid)
            {
                //if(TryUpdateModel(alumno,"",new string[] {"Matricula","Nombre","ApellidoPaterno","ApellidoMaterno", "siglasCarrera", "CorreoElectronico","PasswordHash" }))
                alumno.Carrera = siglasCarrera;

                repositoryA.SaveAlumno(alumno);
                TempData["message"] = string.Format("{0} salvado correctamente", alumno.Matricula);
                return RedirectToAction("Index");
            }
            else
            {
                return View(alumno);
            }
        }
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveTema(tema);
        //        TempData["message"] = string.Format("{0} salvado correctamente", tema.NombreTema);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View(tema);
        //    }
        //}

        //public ViewResult Create()
        //{
        //    return View("Edit", new Tema());
        //}

        //[HttpPost]
        //public ActionResult Delete(string claveTema)
        //{
        //    Tema deletedTema = repository.DeleteTema(claveTema);
        //    if (deletedTema != null)
        //    {
        //        TempData["message"] = string.Format("{0} fue borrado exitósamente", deletedTema.NombreTema);
        //    }
        //    return RedirectToAction("Index");
        //}
    }
}