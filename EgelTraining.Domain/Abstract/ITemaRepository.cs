using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.Domain.Abstract
{
    public interface ITemaRepository
    {
        IEnumerable<Tema> Temas { get;}
        void SaveTema(Tema tema);
        Tema DeleteTema(string claveTema);
    }
}
