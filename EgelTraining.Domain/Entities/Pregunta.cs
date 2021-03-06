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
    
    public partial class Pregunta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pregunta()
        {
            this.QuestionInExams = new HashSet<QuestionInExam>();
            this.RespuestasErroneas = new HashSet<RespuestasErronea>();
            this.Temas = new HashSet<Tema>();
        }
    
        public int IDPregunta { get; set; }
        public string Texto { get; set; }
        public byte[] Imagen { get; set; }
        public short Tipo { get; set; }
        public string TextoRespuesta { get; set; }
        public string RespuestaCorrecta { get; set; }
        public short Dificultad { get; set; }
        public string Nomina { get; set; }
    
        public virtual Profesor Profesor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuestionInExam> QuestionInExams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RespuestasErronea> RespuestasErroneas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tema> Temas { get; set; }
    }
}
