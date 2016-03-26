using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EgelTraining.Domain.Abstract; // notar que esta línea permite usar la interface
using EgelTraining.Domain.Entities; // notar que esta línea permite usar el código generado 


namespace EgelTraining.Domain.Concrete
{
    public class EFProfesorRepository: IProfesorRepository
    {
        private EgelTrainingEntities context = new EgelTrainingEntities();
        public IEnumerable<Profesor> Profesors
        {
            get { return context.Profesors; }
        }

        public void SaveProfesor(Profesor profesor) // si le da RC-> Go to Definition (F12) puede ver la definición de la clase
        {
            Profesor dbEntry = context.Profesors.Find(profesor.Nomina);
            
            if (dbEntry != null) //Si encontró al profesor, actualiza los datos
            {
                dbEntry.Nomina = profesor.Nomina;
                dbEntry.Nombre = profesor.Nombre;
                dbEntry.ApellidoPaterno = profesor.ApellidoPaterno;
                dbEntry.ApellidoMaterno = profesor.ApellidoMaterno;
                dbEntry.CorreoElectronico = profesor.CorreoElectronico;
            }
            else //de lo contrario, lo añade
            {
                context.Profesors.Add(profesor);
            }
            context.SaveChanges();
        }

        public Profesor DeleteProfesor(string nomina)
        {
            Profesor dbEntry = context.Profesors.Find(nomina);
            if (dbEntry != null)
            {
                context.Profesors.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
