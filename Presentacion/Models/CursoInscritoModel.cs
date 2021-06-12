using Microsoft.Win32.SafeHandles;
using System.Reflection;
using System.Linq;
using System;
using Entidad;
using System.Collections.Generic;
using InscritoModel.Model;
using CursoModel.Model;

namespace CursoInscritoModel.Model
{
    public class CursoInscritoInputModel{

        public int IdCursoInscrito { get; set; }
        public int CodigoCurso { get; set; }
        public string Identificacion { get; set; }


    }
    
    public class CursoInscritoViewModel : CursoInscritoInputModel
    {
          
        public  InscritoViewModel Inscrito { get; set; }
        public  CursoViewModel Curso{ get; set; }

        public CursoInscritoViewModel(CursoInscrito cursoInscrito)
        {
            IdCursoInscrito = cursoInscrito.IdCursoInscrito;
            Curso = new CursoViewModel(cursoInscrito.Curso);
            Inscrito = new InscritoViewModel(cursoInscrito.Inscrito);
        }

        
    }
        

}