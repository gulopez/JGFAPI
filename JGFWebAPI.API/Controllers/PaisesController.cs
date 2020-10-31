using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/Paises")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly PaisBussiness _paisBussiness;

        public PaisesController(PaisBussiness paisBussiness)
        {
            _paisBussiness = paisBussiness;
        }

        [HttpGet]
        public IActionResult GetCountries()
        {
            var paises = _paisBussiness.GetEntities();
            return Ok(paises);
        }

        [HttpGet("{id}")]
        public IActionResult GetCountry(Guid id)
        {
            var pais = _paisBussiness.GetEntity(id);
            return Ok(pais);
        }

        [HttpGet("Nombre/{name}")]
        public IActionResult GetCountryByName(string name)
        {
            var estado = _paisBussiness.GetEntityByName(name);
            return Ok(estado);
        }
    }
}