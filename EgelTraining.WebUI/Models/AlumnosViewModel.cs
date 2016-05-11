using System.Collections.Generic;
using EgelTraining.Domain.Entities;
using EgelTraining.Domain.Abstract;
using EgelTraining.Domain.Concrete;

namespace EgelTraining.WebUI.Models
{
    public class AlumnosViewModel
    {
        public IEnumerable<Alumno> Alumnos { get; set; }
    }

}

