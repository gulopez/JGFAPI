using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using JGFWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/SolicitudCupos")]
    [ApiController]
    public class SolicitudCuposController : ControllerBase
    {
        private readonly SolicitudCupoBussiness _solicituCupoBussiness;

        public SolicitudCuposController(SolicitudCupoBussiness solicitudCupoBussiness)
        {
            _solicituCupoBussiness = solicitudCupoBussiness;
        }

        [HttpGet]
        public IActionResult GetQuotaRequest()
        {
            var cupos = _solicituCupoBussiness.GetEntities();
            return Ok(cupos);
        }

        [HttpGet("Usuario/{id}")]
        public IActionResult GetQuotaRequestByUser(Guid id)
        {
            var cupos = _solicituCupoBussiness.GetEntitiesByUsuario(id);
            return Ok(cupos);
        }

        [HttpGet("Alumno/{id}")]
        public IActionResult GetQuotaRequestByStudent(Guid id)
        {
            var cupo = _solicituCupoBussiness.GetEntitiesByStudent(id);
            return Ok(cupo);
        }

        [HttpGet("{id}")]
        public IActionResult GetQuota(Guid id)
        {
            var cupo = _solicituCupoBussiness.GetEntity(id);
            if (cupo == null)
            {
                return NotFound();
            }
            return Ok(cupo);
        }

        [HttpPost]
        public IActionResult CreateQuota([FromBody] SolicitudCupoViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(ModelState);
            }

            //if (_solicituCupoBussiness.ExistsEntity(vm.Id))
            //{
            //    ModelState.AddModelError("", "El cupo ya fue registrado");
            //    return StatusCode(404, ModelState);
            //}

            if (!_solicituCupoBussiness.CreateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo guardar el registro {vm.PrimerNombre} {vm.PrimerApellido}");
                return StatusCode(500, ModelState);
            }

            return Ok(vm);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQuota(Guid id, [FromBody] SolicitudCupoViewModel vm)
        {
            if (vm == null || vm.Id != id)
            {
                return BadRequest(ModelState);
            }

            if (!_solicituCupoBussiness.UpdateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo actualizar el registro {vm.PrimerNombre} {vm.PrimerApellido}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}