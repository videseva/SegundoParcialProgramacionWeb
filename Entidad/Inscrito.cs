  
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Inscrito
    {
        [Key]
        public string Identificacion { get; set; }
        [ForeignKey("Curso")]
        public int CodigoCurso { get; set; }
        public Curso Curso { get; set;}

        public string TipoIdentificacion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set;}

    }
}