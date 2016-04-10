using System.Collections.Generic;
using System.Linq;
using EgelTraining.Domain.Abstract;
using EgelTraining.Domain.Entities;


namespace EgelTraining.Domain.Concrete
{
    public class EFExamenRepository:IExamenRepository
    {
        private EgelTrainingEntities context = new EgelTrainingEntities();
        public IEnumerable<Examan> Examenes
        {
            get { return context.Examen; }
        }

        public void SaveExamen(Examan examen) 
        {
            Examan dbEntry = context.Examen.Find(examen.IDExamen);

            if (dbEntry != null) //Si encontró la carrera, actualiza los datos
            {
                dbEntry.Nombre = examen.Nombre;
                dbEntry.Descripcion = examen.Descripcion;
                dbEntry.FechaDeCreacion = examen.FechaDeCreacion;

            }
            else //de lo contrario, lo añade
            {
                context.Examen.Add(examen);
            }
            context.SaveChanges();
        }

        public Examan DeleteExamen(int IDExamen)
        {
            Examan dbEntry = context.Examen.Find(IDExamen);
            if (dbEntry != null)
            {
                context.Examen.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
