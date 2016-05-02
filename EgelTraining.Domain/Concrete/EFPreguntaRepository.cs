using System.Collections.Generic;
using System.Linq;
using EgelTraining.Domain.Abstract;
using EgelTraining.Domain.Entities;

namespace EgelTraining.Domain.Concrete
{
    public class EFPreguntaRepository:IPreguntaRepository
    {
        private EgelTrainingEntities context = new EgelTrainingEntities();
        public IEnumerable<Pregunta> Preguntas
        {
            get { return context.Preguntas; }
        }

        public void SavePregunta(Pregunta pregunta) 
        {
            Pregunta dbEntry = context.Preguntas.Find(pregunta.IDPregunta);

            if (dbEntry != null) //Si encontró la carrera, actualiza los datos
            {
                dbEntry.IDPregunta = pregunta.IDPregunta;
                dbEntry.Texto = pregunta.Texto;
                dbEntry.Nomina = pregunta.Nomina;
                dbEntry.RespuestaCorrecta = pregunta.RespuestaCorrecta;
                dbEntry.Tipo = pregunta.Tipo;
                dbEntry.TextoRespuesta = pregunta.TextoRespuesta;
                dbEntry.Dificultad = pregunta.Dificultad;

                //checar si la imagen no está vacía
                if (pregunta.Imagen != null && pregunta.Imagen.Length > 0)
                {
                    dbEntry.Imagen = pregunta.Imagen;
                }
            }
            else //de lo contrario, lo añade
            {
                context.Preguntas.Add(pregunta);
            }
            context.SaveChanges();
        }

        public Pregunta DeletePregunta(int IDPregunta)
        {
            Pregunta dbEntry = context.Preguntas.Find(IDPregunta);
            if (dbEntry != null)
            {
                context.Preguntas.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
