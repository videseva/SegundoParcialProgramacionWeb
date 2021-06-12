  
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Inscrito
    {
        [Key]
        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set;}
        public List<CursoInscrito> CursoInscritos{ get; set;}

    }
}