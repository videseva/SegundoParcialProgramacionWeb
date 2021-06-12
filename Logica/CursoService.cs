using System;
using Datos;
using Entidad;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Logica
{
    public class CursoService
    {
        private readonly ParcialDbContext _context;

        public CursoService(ParcialDbContext context)
        {
            _context = context;
        }

        public GuardarCursoResponse GuardarCurso (Curso curso)
        {
            try
            {
                var _curso = _context.Cursos.Find(curso.CodigoCurso);

                if (_curso != null)
                {
                    return new GuardarCursoResponse("El codigo ya se encuentra registrado");                    
                }else if(curso.CuposDisponibles <= 0){
                    return new GuardarCursoResponse("El cupo disponible debe ser mayor que cero ");   
                }
                _context.Cursos.Add(curso);
                _context.SaveChanges();
                return new GuardarCursoResponse(curso);
            }
            catch (Exception e)
            {
                return new GuardarCursoResponse("Ocurrieron algunos Errores:" + e.Message);   
            }
        }

        public ConsultarCursoResponse Consultar()
        {
            try
            {
                var Cursos = _context.CursoInscritos.Include(x => x.Curso).Include(a => a.Inscrito).ToList();
                return new ConsultarCursoResponse(Cursos);
            }
            catch (Exception e)
            {
                return new ConsultarCursoResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }

        public ConsultarCursoResponse ConsultarCursosConInscritos()
        {
            try
            {
                var Cursos = _context.Cursos.Include(x => x.CursoInscritos).Include(a => a.Inscrito).ToList();
                return new ConsultarCursoResponse(Cursos);
            }
            catch (Exception e)
            {
                return new ConsultarCursoResponse("Ocurriern algunos Errores:" + e.Message);
            }
        }
    }

    public class ConsultarCursoResponse
    {
        public List<CursoInscrito> CursoInscritos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public ConsultarCursoResponse(List<CursoInscrito> cursos)
        {
            CursoInscritos = cursos;
            Error = false;
        }

        public ConsultarCursoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
    public class GuardarCursoResponse
    {
        public Curso Curso { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }


        public GuardarCursoResponse(Curso curso)
        {
            Curso = curso;
            Error = false;
        }

        public GuardarCursoResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

}
