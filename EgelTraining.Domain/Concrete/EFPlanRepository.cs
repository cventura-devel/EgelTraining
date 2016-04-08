using System.Collections.Generic;
using System.Linq;
using EgelTraining.Domain.Abstract;
using EgelTraining.Domain.Entities;


namespace EgelTraining.Domain.Concrete
{
    public class EFPlanRepository:IPlanRepository
    {
        private EgelTrainingEntities context = new EgelTrainingEntities();
        public IEnumerable<PlanEstudio> Planes
        {
            get { return context.PlanEstudios.Include("Carrera"); }
        }

        public void SavePlan(PlanEstudio plan) 
        {
            PlanEstudio dbEntry = context.PlanEstudios.Find(plan.Siglas, plan.Plan);

            if (dbEntry != null) //Si encontró la carrera, actualiza los datos
            {
                dbEntry.Siglas = plan.Siglas;
                dbEntry.Plan = plan.Plan;

            }
            else //de lo contrario, lo añade
            {
                context.PlanEstudios.Add(plan);
            }
            context.SaveChanges();
        }

        public PlanEstudio DeletePlan(string siglas, string plan)
        {
            PlanEstudio dbEntry = context.PlanEstudios.Find(siglas, plan);
            if (dbEntry != null)
            {
                context.PlanEstudios.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
