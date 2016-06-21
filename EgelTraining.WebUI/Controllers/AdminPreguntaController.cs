using System.Web.Mvc;
using EgelTraining.Domain.Abstract;
using System.Linq;
using EgelTraining.Domain.Entities;
using System.Web;


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

            PopulateCarrerasDropDownList(carrera);
            PopulateTemasDropDownList(carrera,claveTema);
            return View(repository.Preguntas);
        }


        public ViewResult Edit(int iDPregunta)
        {
            Pregunta pregunta = repository.Preguntas.FirstOrDefault(p => p.IDPregunta == iDPregunta);
            return View(pregunta);
        }

        [HttpPost]
        public ActionResult Edit(Pregunta pregunta,HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    pregunta.Imagen = new byte[image.ContentLength];
                    image.InputStream.Read(pregunta.Imagen, 0, image.ContentLength);
                }
                repository.SavePregunta(pregunta);
                TempData["message"] = string.Format("{0} salvado exitosamente", pregunta.Texto);
                return RedirectToAction("Index");
            }
            else {
                return View(pregunta);
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
        }

        private void PopulateTemasDropDownList(string carrera, object selectedClaveTema = null)
        {
            var temasQuery = repositoryCarrera.Carreras.Where(i => i.Siglas == carrera).Single().Temas;
            ViewBag.ClaveTema = new SelectList(temasQuery, "ClaveTema", "NombreTema", selectedClaveTema);
        }

    }
}