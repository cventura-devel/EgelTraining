using System.Collections.Generic;
using System.Linq;
using EgelTraining.Domain.Abstract;
using EgelTraining.Domain.Entities;


namespace EgelTraining.Domain.Concrete
{
    public class EFCarreraRepository: ICarreraRepository //error común de novato, olivar hacer la clase public!!!!!!!!!
    {
        private EgelTrainingEntities context = new EgelTrainingEntities();
        public IEnumerable<Carrera> Carreras
        {
            get { return context.Carreras; } //FUNCIONA CON PLURAL. Con singular truena (make sense)
            //get { return context.Carreras.Include("Temas"); } //FUNCIONA CON PLURAL. Con singular truena (make sense)
            //NO REQUIERE EL INCLUDE, FUNCIONA SOLO ASÍ COMO ESTÁ EL CÓDIGO
        }


        public void SaveCarrera(Carrera carrera) // si le da RC-> Go to Definition (F12) puede ver la definición de la clase
        {
            Carrera dbEntry = context.Carreras.Find(carrera.Siglas);

            if (dbEntry != null) //Si encontró la carrera, actualiza los datos
            {
                dbEntry.Siglas = carrera.Siglas;
                dbEntry.NombreLargo = carrera.NombreLargo;
               
            }
            else //de lo contrario, lo añade
            {
                context.Carreras.Add(carrera);
            }
            context.SaveChanges();
        }

        public Carrera DeleteCarrera(string siglas)
        {
            Carrera dbEntry = context.Carreras.Find(siglas);
            if (dbEntry != null)
            {
                context.Carreras.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
