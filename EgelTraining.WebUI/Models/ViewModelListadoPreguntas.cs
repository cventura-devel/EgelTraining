using System.Collections.Generic;
using EgelTraining.Domain.Entities;
namespace EgelTraining.WebUI.Models
{
    public class ViewModelListadoPreguntas
    {
        public IEnumerable<Pregunta> preguntas { set; get; }

        public string CurrentCarrera { set; get; }

        public string CurrentTema { set; get; }

    }
}