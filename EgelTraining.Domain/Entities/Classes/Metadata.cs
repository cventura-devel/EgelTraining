using System;
using System.ComponentModel.DataAnnotations;

namespace EgelTraining.Domain.Entities
{
    public class CarreraMetadata
    {
        [StringLength(4)]
        public string Siglas { set; get; } 
    }

}
