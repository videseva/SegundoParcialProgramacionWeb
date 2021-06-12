  
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Entidad
{
    public class CursoInscrito
    {
        [Key]
        public int CodigoCursoInscrito { get; set; }

        [ForeignKey("Curso")]
        public int CodigoCurso { get; set; }
        public Curso Curso { get; set;}

        [ForeignKey("Inscrito")]
        public string Identificacion { get; set; }
        public Inscrito Inscrito { get; set;}


    }
}