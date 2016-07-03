using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.WebUI.Models
{
    public class ViewModelAltaEditPregunta
    {
        public Pregunta pregunta { set; get; } //este se usa para los datos de la pregunta

         
        public IEnumerable<RespuestasErronea> respuestasErroneas { set; get; } //respuestas erroneas

        //public AltaPreguntaInfo AltaPreguntaInfo { set; get; } //igual y puede desaparecer

        //estas variables las quiero utilizar para saber qué tema y carrera seleccionó el profesor, y sobre qué estará trabajando
        public string CurrentCarrera { set; get; }

        public string CurrentTema { set; get; } 

    }
}