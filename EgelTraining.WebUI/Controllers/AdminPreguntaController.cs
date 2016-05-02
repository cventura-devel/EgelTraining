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

        public AdminPreguntaController(IPreguntaRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
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

    }
}