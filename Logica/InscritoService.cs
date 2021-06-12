using System.ComponentModel.Design.Serialization;
using System.ComponentModel;
using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class InscritoService
    {
        private readonly ParcialDbContext _context;

        public InscritoService(ParcialDbContext context)
        {
            _context = context;
        }

        public GuardarInscritoResponse GuardarCurso (Inscrito inscrito , int codigoCurso)
        {
            try
            {
                var _curso = _context.Cursos.Find(codigoCurso);

                DateTime fechaActual = DateTime.Today;
                var anios = fechaActual.Year - inscrito.FechaNacimiento.Year;

                if (_curso == null)
                {
                    return new GuardarInscritoResponse("El codigo no se encuentra registrado");                    
                }else if(_curso.CuposDisponibles == 0){
                    return new GuardarInscritoResponse("El Curso no tiene cupos disponible");   
                }else if(anios < 12 || anios > 16){
                    return new GuardarInscritoResponse("La edad no se encuentra entre los 12 y 16 años"); 
                }

                /*
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                return new GuardarInscritoResponse(curso);*/
            }
            catch (Exception e)
            {
                return new GuardarInscritoResponse("Ocurrieron algunos Errores:" + e.Message);   
            }
        }


    }

    public class GuardarInscritoResponse
    {
        public Inscrito Inscrito { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarInscritoResponse(Inscrito inscrito)
        {
            Inscrito = inscrito;
            Error = false;
        }

        public GuardarInscritoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }



}