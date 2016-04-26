using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.Domain.Abstract
{
    public interface IPreguntaRepository
    {
        IEnumerable<Pregunta> Preguntas { get; }
        void SavePregunta(Pregunta pregunta);
        Pregunta DeletePregunta(int ID);
    }
}
