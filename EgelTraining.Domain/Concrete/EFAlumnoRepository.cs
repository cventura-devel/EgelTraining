using System.Collections.Generic;
using System.Linq;
using EgelTraining.Domain.Abstract;
using EgelTraining.Domain.Entities;

namespace EgelTraining.Domain.Concrete
{
    public class EFAlumnoRepository:IAlumnoRepository
    {
        private EgelTrainingEntities context = new EgelTrainingEntities();
        public IEnumerable<Alumno> Alumnos
        {
            get { return context.Alumnoes; }
        }

        public void SaveAlumno(Alumno alumno) 
        {
            Alumno dbEntry = context.Alumnoes.Find(alumno.Matricula);

            if (dbEntry != null) //Si encontró la carrera, actualiza los datos
            {
                dbEntry.Matricula = alumno.Matricula;
                dbEntry.Nombre = alumno.Nombre;
                dbEntry.ApellidoPaterno = alumno.ApellidoPaterno;
                dbEntry.ApellidoMaterno = alumno.ApellidoMaterno;
                dbEntry.Carrera = alumno.Carrera;
                dbEntry.CorreoElectronico = alumno.CorreoElectronico;


            }
            else //de lo contrario, lo añade
            {
                context.Alumnoes.Add(alumno);
            }
            context.SaveChanges();
        }

        public Alumno DeleteAlumno(string matricula)
        {
            Alumno dbEntry = context.Alumnoes.Find(matricula);
            if (dbEntry != null)
            {
                context.Alumnoes.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
