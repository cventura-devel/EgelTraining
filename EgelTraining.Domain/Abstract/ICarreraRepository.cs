using System.Collections.Generic;
using EgelTraining.Domain.Entities;


namespace EgelTraining.Domain.Abstract
{
    public interface ICarreraRepository
    {
        IEnumerable<Carrera> Carreras { get; }
        void SaveCarrera(Carrera carrera);
        Carrera DeleteCarrera(string ID);
    }
}
