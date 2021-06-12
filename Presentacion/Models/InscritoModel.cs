using Microsoft.Win32.SafeHandles;
using System.Reflection;
using System.Linq;
using System;
using Entidad;
using System.Collections.Generic;

namespace InscritoModel.Model
{
    public class InscritoInputModel{

        public string Identificacion { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set;}
    }
    
     public class InscritoViewModel : InscritoInputModel {
        public InscritoViewModel(Inscrito inscrito)
        {
            Identificacion = inscrito.Identificacion;
            TipoIdentificacion = inscrito.TipoIdentificacion;
            Nombre = inscrito.Nombre;
            FechaNacimiento = inscrito.FechaNacimiento;

        }
    }
}