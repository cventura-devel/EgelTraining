//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EgelTraining.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlanEstudio
    {
        public string Siglas { get; set; }
        public string Plan { get; set; }
    
        public virtual Carrera Carrera { get; set; }
    }
}
