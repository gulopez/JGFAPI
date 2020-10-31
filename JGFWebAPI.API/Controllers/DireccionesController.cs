using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/Direcciones")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class DireccionesController : ControllerBase
    {
        private readonly DireccionBussiness _direccionBussiness;

        public DireccionesController(DireccionBussiness direccionBussiness)
        {
            _direccionBussiness = direccionBussiness;
        }

        [HttpGet("{id}")]
        public IActionResult GetAddress(Guid id)
        {
            var direccion = _direccionBussiness.GetEntity(id);
            if (direccion == null)
            {
                return NotFound();
            }
            return Ok(direccion);
        }
    }
}