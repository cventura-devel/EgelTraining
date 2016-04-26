using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.WebUI.Models
{
    public class ContestaExamenViewModel
    {
        public IEnumerable<Pregunta> Preguntas { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}