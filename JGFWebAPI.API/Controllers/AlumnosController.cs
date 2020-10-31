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
    [Route("api/Alumnos")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class AlumnosController : ControllerBase
    {
        private readonly AlumnoBussiness _alumnoBussiness;
        private readonly RepresentanteBussiness _representanteBussiness;
        private readonly DireccionBussiness _direccionBussiness;
        private readonly DatoMedicoBussiness _datoMedicoBussiness;
        private readonly DatoFamiliarBussiness _datoFamiliarBussiness;

        public AlumnosController(AlumnoBussiness alumnoBussiness, RepresentanteBussiness representanteBussiness,
                                DireccionBussiness direccionBussiness, DatoMedicoBussiness datoMedicoBussiness,
                                DatoFamiliarBussiness datoFamiliarBussiness)
        {
            _alumnoBussiness = alumnoBussiness;
            _representanteBussiness = representanteBussiness;
            _direccionBussiness = direccionBussiness;
            _datoMedicoBussiness = datoMedicoBussiness;
            _datoFamiliarBussiness = datoFamiliarBussiness;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var alumnos = _alumnoBussiness.GetEntities();
            return Ok(alumnos);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(Guid id)
        {
            var alumno = _alumnoBussiness.GetEntity(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        [HttpGet("Representante/{id}")]
        public IActionResult GetStudentsByRepresentative(Guid id)
        {
            var alumnos = _alumnoBussiness.GetEntitiesByRepresentative(id, true);
            if (alumnos == null)
            {
                return NotFound();
            }
            return Ok(alumnos);
        }

        [HttpGet("Existe/Cedula/{cardId}")]
        public IActionResult GetStudentsByCardId(string cardId)
        {
            if (!_alumnoBussiness.ExistsEntityByCardId(cardId))
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("PreInscripcion")]
        public IActionResult GetStudentsByPreInscription()
        {
            var alumnos = _alumnoBussiness.GetEntitiesByPreInscription();
            if (alumnos == null)
            {
                return NotFound();
            }
            return Ok(alumnos);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] AlumnoViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(ModelState);
            }

            if (_alumnoBussiness.ExistsEntity(vm.Id))
            {
                ModelState.AddModelError("", "El alumno ya se encuentra registrado");
                return StatusCode(404, ModelState);
            }

            if (!_alumnoBussiness.CreateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo guardar el registro {vm.PrimerNombre} {vm.PrimerApellido}");
                return StatusCode(500, ModelState);
            }

            return Ok(vm);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Guid id, [FromBody] AlumnoViewModel vm)
        {
            if (vm == null || vm.Id != id)
            {
                return BadRequest(ModelState);
            }

            if (!_alumnoBussiness.UpdateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo actualizar el registro {vm.PrimerNombre} {vm.PrimerApellido}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(Guid id)
        {
            if (!_alumnoBussiness.ExistsEntity(id))
            {
                return NotFound();
            }

            var alumno = _alumnoBussiness.GetEntity(id);
            alumno.Direccion.EstadoProvincia = null;
            alumno.PeriodoEscolar = null;
            alumno.GradoEscolar = null;
            alumno.Padre.Direccion.EstadoProvincia = null;
            alumno.Madre.Direccion.EstadoProvincia = null;
            alumno.Representante.Direccion.EstadoProvincia = null;

            if (!_alumnoBussiness.DeleteEntity(alumno))
            {
                ModelState.AddModelError("", $"No se pudo eliminar el registro {alumno.PrimerNombre} {alumno.PrimerApellido}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("Buscar/{keyword}")]
        public IActionResult GetStudentsByKeyword(string keyword)
        {
            var alumnos = _alumnoBussiness.GetEntitiesByKeyword(keyword);
            if (alumnos == null)
            {
                return NotFound();
            }
            return Ok(alumnos);
        }
    }
}