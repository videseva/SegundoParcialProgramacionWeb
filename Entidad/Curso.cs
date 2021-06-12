  
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Curso
    {
        [Key]
        public int codigo { get; set; }
        public string Nombre { get; set; }
        public int CuposDisponibles { get; set; }

    }
}
