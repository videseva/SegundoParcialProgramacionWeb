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

        public GuardarInscritoResponse GuardarIsncrito (Inscrito inscrito)
        {
            try
            {
                var _inscrito = _context.Inscritos.Find(inscrito.Identificacion);
                var _curso = _context.Cursos.Find(inscrito.CodigoCurso);

                if (_curso != null)
                {
                    return new GuardarCursoResponse("El codigo ya se encuentra registrado");                    
                }else if(curso.CuposDisponibles <= 0){
                    return new GuardarCursoResponse("El cupo disponible debe ser mayor que cero ");   
                }
            }
            catch (Exception e)
            {
                return new GuardarCursoResponse("Ocurrieron algunos Errores:" + e.Message);   
            }
        }

    }

    public class ConsultarInscritoResponse
    {
        public List<Inscrito> Inscritos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarInscritoResponse(List<Inscrito> inscritos)
        {
            Inscritos = inscritos;
            Error = false;
        }

        public ConsultarInscritoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
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