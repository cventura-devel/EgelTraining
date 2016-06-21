using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;
using System.Web;
using EgelTraining.WebUI.Models;


namespace EgelTraining.WebUI.Controllers
{
    public class AdminMainPreguntaController : Controller
    {

        ICarreraRepository repository;

        public AdminMainPreguntaController(ICarreraRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index(string carrera, string claveTema)
        {

            var viewModel = new ViewModelMainPreguntas();
            viewModel.carreras = repository.Carreras;

            if(carrera != null)
            {
                ViewBag.Carrera = carrera;
                viewModel.temas = viewModel.carreras.Where(i => i.Siglas == carrera).Single().Temas;
                #region Comments 
                //The Where method returns a collection, but in this case the criteria passed to that method result in only a single Carreta entity being returned. 
                //The Single method converts the collection into a single Carrera entity, which gives you access to that entity's Temas property.
                //ver nota detro de la clase EFCarreraRepository, pero no se quiere el include en el EFCarreraRepository
                #endregion
            }
            if(claveTema != null)
            {
                ViewBag.ClaveTema = claveTema;
            }




            return View(viewModel);
            //recodar que ya esta incluido desde el EFCarreras el include a Tema

            //TODO, crear un boton que me lleve a otra forma, donde ya pueda crear las preguntas de acuerdo al tema y carrera seleccionados
        }
    }

}