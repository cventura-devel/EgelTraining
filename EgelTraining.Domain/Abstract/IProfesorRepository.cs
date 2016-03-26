using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.Domain.Abstract
{
    public interface IProfesorRepository
    {
        IEnumerable<Profesor> Profesors { get; }
        void SaveProfesor(Profesor profesor);
        Profesor DeleteProfesor(string nomina);
    }
}
