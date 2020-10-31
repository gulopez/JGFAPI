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
    [Route("api/Representantes")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class RepresentantesController : ControllerBase
    {
        private readonly RepresentanteBussiness _representantesBussiness;

        public RepresentantesController(RepresentanteBussiness representanteBussiness)
        {
            _representantesBussiness = representanteBussiness;
        }

        [HttpGet]
        public IActionResult GetRepresentatives()
        {
            var representantes = _representantesBussiness.GetEntities();
            return Ok(representantes);
        }

        [HttpGet("{id}")]
        public IActionResult GetRepresentative(Guid id)
        {
            var representante = _representantesBussiness.GetEntity(id);
            if (representante == null)
            {
                return NotFound();
            }
            return Ok(representante);
        }

        [HttpPost]
        public IActionResult CreateRepresentative([FromBody] RepresentanteViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(ModelState);
            }

            if (_representantesBussiness.ExistsEntity(vm.Id))
            {
                ModelState.AddModelError("", "El representante ya se encuentra registrado");
                return StatusCode(404, ModelState);
            }

            if (!_representantesBussiness.CreateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo guardar el registro {vm.PrimerNombre} {vm.PrimerApellido}");
                return StatusCode(500, ModelState);
            }

            return Ok(vm);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRepresentative(Guid id, [FromBody] RepresentanteViewModel vm)
        {
            if (vm == null || vm.Id != id)
            {
                return BadRequest(ModelState);
            }

            if (_representantesBussiness.ExistsEntity(vm.CedulaRepresentante))
            {
                if (!_representantesBussiness.UpdateEntity(vm))
                {
                    ModelState.AddModelError("", $"No se pudo actualizar el registro {vm.PrimerNombre} {vm.PrimerApellido}");
                    return StatusCode(500, ModelState);
                }
            }
            else
            {
                if (!_representantesBussiness.CreateEntity(vm))
                {
                    ModelState.AddModelError("", $"No se pudo actualizar el registro {vm.PrimerNombre} {vm.PrimerApellido}");
                    return StatusCode(500, ModelState);
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRepresentative(Guid id)
        {
            if (!_representantesBussiness.ExistsEntity(id))
            {
                return NotFound();
            }

            var representante = _representantesBussiness.GetEntity(id);

            if (!_representantesBussiness.UpdateEntity(representante))
            {
                ModelState.AddModelError("", $"No se pudo actualizar el registro {representante.PrimerNombre} {representante.PrimerApellido}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("Cedula")]
        public IActionResult GetByCardId(string cardId)
        {
            var representante = _representantesBussiness.GetEntityByCardId(cardId);
            if (representante == null)
            {
                return NotFound();
            }

            return Ok(representante);
        }
    }
}