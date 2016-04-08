using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.Domain.Abstract
{
    public interface IPlanRepository
    {

        IEnumerable<PlanEstudio> Planes { get; }
        void SavePlan(PlanEstudio plan);
        PlanEstudio DeletePlan(string siglas, string plan);
    }
}
