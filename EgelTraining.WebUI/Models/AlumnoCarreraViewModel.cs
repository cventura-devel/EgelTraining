using System.Collections.Generic;
using EgelTraining.Domain.Entities;
using EgelTraining.Domain.Abstract;
using EgelTraining.Domain.Concrete;

namespace EgelTraining.WebUI.Models
{
    public class AlumnoCarreraViewModel
    {
        public Alumno Alumno { get; set; }
        public IEnumerable<Carrera> Carreras { get; set; }
    }

}

