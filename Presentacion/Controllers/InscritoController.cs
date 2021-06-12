using System.Threading;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Logica;
using Datos;
using Entidad;
using InscritoModel.Model;

 namespace Presentacion.controller 
    {
        [Route("api/[controller]")]
        [ApiController]

        public class InscritoControllers : ControllerBase{
            
            private InscritoService _inscritoService;

            public InscritoControllers (ParcialDbContext context)
            {
                _inscritoService = new InscritoService(context);
            }

            [HttpPost("{codigoCurso}")]
            public ActionResult <InscritoViewModel> PostInscrito(InscritoInputModel inscritoInputModel,int codigoCurso)
            {   
                var inscrito = MapearInscrito(inscritoInputModel);
                var response = _inscritoService.GuardarCurso(inscrito,codigoCurso);

                if (!response.Error)
                {
                    var inscritoViewModel = new InscritoViewModel(inscrito);
                    return Ok(inscritoViewModel);
                }
                return BadRequest(response.Mensaje);
            }

            private Inscrito MapearInscrito(InscritoInputModel inscritoInputModel){

                var _inscrito = new Inscrito(){
                Identificacion = inscritoInputModel.Identificacion,
                TipoIdentificacion = inscritoInputModel.TipoIdentificacion,
                Nombre = inscritoInputModel.Nombre,
                FechaNacimiento = inscritoInputModel.FechaNacimiento,
                };
                return _inscrito;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
            }
        }
    }