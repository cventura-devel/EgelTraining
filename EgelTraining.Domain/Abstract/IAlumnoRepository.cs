using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.Domain.Abstract
{
    public interface IAlumnoRepository
    {
        IEnumerable<Alumno> Alumnos { get; }
        void SaveAlumno(Alumno alumno);
        Alumno DeleteAlumno(string matricula);
    }
}
