using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/ProvinciaEstados")]
    [ApiController]
    public class ProvinciaEstadosController : ControllerBase
    {
        private readonly EstadoProvinciaBussiness _estadoBussiness;

        public ProvinciaEstadosController(EstadoProvinciaBussiness estadoBussiness)
        {
            _estadoBussiness = estadoBussiness;
        }

        [HttpGet]
        public IActionResult GetStates()
        {
            var estados = _estadoBussiness.GetEntities();
            return Ok(estados);
        }

        [HttpGet("Pais/{id}")]
        public IActionResult GetStatesByCountry(Guid id)
        {
            var estados = _estadoBussiness.GetEntitiesByCountry(id);
            return Ok(estados);
        }

        [HttpGet("{id}")]
        public IActionResult GetState(Guid id)
        {
            var estado = _estadoBussiness.GetEntity(id);
            return Ok(estado);
        }

        [HttpGet("Nombre/{name}")]
        public IActionResult GetStateByName(string name)
        {
            var estado = _estadoBussiness.GetEntityByName(name);
            return Ok(estado);
        }
    }
}