using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.WebUI.Models
{
    public class ViewModelMainPreguntas
    {

        //public IEnumerable<Pregunta> preguntas { set; get; }
        public IEnumerable<Carrera> carreras { set; get; }
        
        public IEnumerable<Tema> temas { set; get; }

        public Profesor profesor { set; get; }

    }
}