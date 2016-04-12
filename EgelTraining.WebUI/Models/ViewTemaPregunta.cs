using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.WebUI.Models
{
    public class ViewTemaPregunta
    {
        public  IEnumerable<Tema> Temas { get; set; }
        public IEnumerable<Pregunta> Preguntas { get; set; }
        
    }
}