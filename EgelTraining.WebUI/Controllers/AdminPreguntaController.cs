using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;
using System.Web;
using EgelTraining.WebUI.Models;


namespace EgelTraining.WebUI.Controllers
{
    public class AdminPreguntaController : Controller
    {

        IPreguntaRepository repository;
        ICarreraRepository repositoryCarrera;

        public AdminPreguntaController(IPreguntaRepository repo, ICarreraRepository repoC)
        {
            repository = repo;
            repositoryCarrera = repoC;
        }

        public ActionResult Index(string carrera, string claveTema)
        {

            //esto es para seguir la convencion de que al entrar a AdminPregunta (donde se dan de alta) se muestran las preguntas filtradas por tema y carrera
            //creamos el modelo con el cual vamos a regresar
            //el modelo solo debe de tener las preguntas a mostrar y motrarse las categorias que hay en este momento activas (carreras y temas)

            ViewModelListadoPreguntas model = new ViewModelListadoPreguntas
            {
                preguntas = repository.Preguntas.Where(p => claveTema == null || p.Temas.Any(t => t.ClaveTema == claveTema)),  //preguntas = repository.Preguntas.Where(p => p.Temas.Any(t => t.ClaveTema == claveTema)),

                CurrentCarrera = carrera,
                CurrentTema = claveTema
            };



            string j = null;
            string k = null;

            if (carrera != null)
                PopulateCarrerasDropDownList(carrera);
            else
            {
                
                try
                {
                    j = TempData["carrera"].ToString();
                }
                catch (System.NullReferenceException) {
                    j = null;
                }

                try
                {
                    k = TempData["tema"].ToString();
                }
                catch (System.NullReferenceException)
                {
                    k = null;
                }

                PopulateCarrerasDropDownList(j);
            }

            var query = repository.Preguntas.Where(p => claveTema == null || p.Temas.Any(t => t.ClaveTema == claveTema));

            if (claveTema != null)
                PopulateTemasDropDownList(carrera,claveTema);
            else
            {
                PopulateTemasDropDownList("ITIC", k);

            }

            //return View(repository.Preguntas); --Cambiado para filtrar y que solo salgan las preguntas del tema/carrera
            return View(model);
        }

        public ViewResult Create()
        {
            return View("Edit", new Pregunta());
        }


        public ViewResult Edit(int iDPregunta,string selectedSiglasCarrera,string selectedClaveTema)//,77 string tema1, string returnUrl)//version mejorada
        {


            ViewModelAltaEditPregunta viewModel = new ViewModelAltaEditPregunta();
            viewModel.CurrentCarrera = selectedSiglasCarrera;
            viewModel.CurrentTema = selectedClaveTema;

            Pregunta pregunta = repository.Preguntas.FirstOrDefault(p => p.IDPregunta == iDPregunta);
            viewModel.pregunta = pregunta;

            //viewModel.AltaPreguntaInfo = new AltaPreguntaInfo();
           
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ViewModelAltaEditPregunta viewModel, string carrera, string claveTema, HttpPostedFileBase image = null )
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    viewModel.pregunta.Imagen = new byte[image.ContentLength];
                    image.InputStream.Read(viewModel.pregunta.Imagen, 0, image.ContentLength);
                }
                repository.SavePregunta(viewModel.pregunta);
                TempData["message"] = string.Format("{0} salvado exitosamente", viewModel.pregunta.Texto);
                return RedirectToAction("Index", new { carrera ,  claveTema });
            }
            else {
                return View(viewModel.pregunta);
            }
        }



        public FileContentResult GetImage(int iDPregunta)
        {
            Pregunta pregunta = repository.Preguntas.FirstOrDefault(p => p.IDPregunta == iDPregunta);
            if(pregunta != null)
            {
                return File(pregunta.Imagen, "image/png");
            }
            else
            {
                return null;
            }

        }

        private void PopulateCarrerasDropDownList(object selectedCarrera = null)
        {
            var carrerasQuery = repositoryCarrera.Carreras;
            ViewBag.SiglasCarrera = new SelectList(carrerasQuery, "Siglas", "NombreLargo", selectedCarrera);
            ViewBag.selectedSiglasCarrera = selectedCarrera;
        }

        private void PopulateTemasDropDownList(string carrera, object selectedClaveTema = null)
        {
            var temasQuery = repositoryCarrera.Carreras.Where(i => i.Siglas == carrera).Single().Temas;
            ViewBag.ClaveTema = new SelectList(temasQuery, "ClaveTema", "NombreTema", selectedClaveTema);
            ViewBag.selectedClaveTema = selectedClaveTema;
        }

    }
}