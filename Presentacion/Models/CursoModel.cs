using Microsoft.Win32.SafeHandles;
using System.Reflection;
using System.Linq;
using System;
using Entidad;
using System.Collections.Generic;

namespace CursoModel.Model
{
    public class CursoInputModel{

        public int CodigoCurso { get; set; }
        public string Nombre { get; set; }
        public int CuposDisponibles { get; set; }
    }
    
     public class CursoViewModel : CursoInputModel {
        public CursoViewModel(Curso curso)
        {
            CodigoCurso = curso.CodigoCurso;
            Nombre = curso.Nombre;
            CuposDisponibles = curso.CuposDisponibles;
        }
    }
}