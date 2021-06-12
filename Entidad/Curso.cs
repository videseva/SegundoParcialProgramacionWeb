  
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Entidad
{
    public class Curso
    {
        [Key]
        public int CodigoCurso { get; set; }
        public string Nombre { get; set; }
        public int CuposDisponibles { get; set; }
        public List<CursoInscrito> CursoInscritos{ get; set;}

    }
}
