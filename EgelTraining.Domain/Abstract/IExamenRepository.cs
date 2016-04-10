using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.Domain.Abstract
{
    public interface IExamenRepository
    {
        IEnumerable<Examan> Examenes { get; }
        void SaveExamen(Examan examen);
        Examan DeleteExamen(int IDExamen);
    }
}
