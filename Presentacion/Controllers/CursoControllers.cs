using System.Threading;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Datos;
using Entidad;
using CursoModel.Model;
using CursoInscritoModel.Model;

namespace Presentacion.controller 
    {
        [Route("api/[controller]")]
        [ApiController]

        public class CursoControllers : ControllerBase{
            
            private CursoService _cursoService;

            public CursoControllers (ParcialDbContext context)
            {
                _cursoService = new CursoService(context);
            }

            [HttpPost]
            public ActionResult <CursoViewModel> PostCurso(CursoInputModel cursoInputModel)
            {   
                var curso = MapearCurso(cursoInputModel);
                var response = _cursoService.GuardarCurso(curso);

                if (!response.Error)
                {
                    var cursoViewModel = new CursoViewModel(curso);
                    return Ok(cursoViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            [HttpGet]
            public ActionResult<IEnumerable<CursoInscritoViewModel>>GetCursos()
            {
                  var response = _cursoService.Consultar();
                if (!response.Error)
                {
                    var cursoInscritoViewModel = response.CursoInscritos.Select(p => new CursoInscritoViewModel(p));
                    return Ok(cursoInscritoViewModel);
                }
                return BadRequest(response.Mensaje);
            }
            private Curso MapearCurso(CursoInputModel cursoInputModel){

                var _curso = new Curso(){                    
                    CodigoCurso = cursoInputModel.CodigoCurso,
                    Nombre = cursoInputModel.Nombre,
                    CuposDisponibles = cursoInputModel.CuposDisponibles,
                };
                return _curso;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
            }
        }
    }