using System.Collections.Generic;
using EgelTraining.Domain.Entities;

namespace EgelTraining.WebUI.Models
{
    public class ExamenesListViewModel
    {
        public IEnumerable<Examan> Examenes { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}