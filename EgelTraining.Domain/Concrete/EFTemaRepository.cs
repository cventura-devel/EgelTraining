using System.Collections.Generic;
using System.Linq;
using EgelTraining.Domain.Abstract;
using EgelTraining.Domain.Entities;


namespace EgelTraining.Domain.Concrete
{
    public class EFTemaRepository : ITemaRepository
    {
        private EgelTrainingEntities context = new EgelTrainingEntities();
        public IEnumerable<Tema> Temas
        {
            get { return context.Temas.Include("Preguntas"); }
        }

        public void SaveTema(Tema tema) 
        {
            Tema dbEntry = context.Temas.Find(tema.ClaveTema);

            if (dbEntry != null) 
            {
                dbEntry.ClaveTema = tema.ClaveTema;
                dbEntry.NombreTema = tema.NombreTema;

            }
            else //de lo contrario, lo añade
            {
                context.Temas.Add(tema);
            }
            context.SaveChanges();
        }

        public Tema DeleteTema(string clavetema)
        {
            Tema dbEntry = context.Temas.Find(clavetema);
            if (dbEntry != null)
            {
                context.Temas.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
