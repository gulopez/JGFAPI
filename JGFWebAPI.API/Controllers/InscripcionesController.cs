using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using JGFWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/Inscripciones")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class InscripcionesController : ControllerBase
    {
        private readonly PreInscripcionBussiness _preInscripcionBussiness;

        public InscripcionesController(PreInscripcionBussiness preInscripcionBussiness)
        {
            _preInscripcionBussiness = preInscripcionBussiness;
        }

        [HttpGet("PreInscripcion/{id}")]
        public IActionResult GetPreInscription(Guid id)
        {
            var preinscripcion = _preInscripcionBussiness.GetEntity(id);
            if (preinscripcion == null)
            {
                return NotFound();
            }

            return Ok(preinscripcion);
        }

        [HttpGet("PreInscripcion")]
        public IActionResult GetPreInscriptions()
        {
            var preinscripciones = _preInscripcionBussiness.GetEntities();
            return Ok(preinscripciones);
        }

        [HttpPost("PreInscripcion")]
        public IActionResult CreatePreInscription([FromBody] PreInscripcionViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(ModelState);
            }

            if (_preInscripcionBussiness.ExistsEntity(vm.IdAlumno))
            {
                ModelState.AddModelError("", "El alumno ya se encuentra registrado");
                return StatusCode(404, ModelState);
            }

            if (!_preInscripcionBussiness.CreateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo guardar la preinscripción");
                return StatusCode(500, ModelState);
            }

            return Ok(vm);
        }
    }
}