using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/EstadosCiviles")]
    [ApiController]
    public class EstadosCivilesController : ControllerBase
    {
        private readonly EstadoCivilBussiness _estadoCivilBussines;

        public EstadosCivilesController(EstadoCivilBussiness estadoCivilBussiness)
        {
            _estadoCivilBussines = estadoCivilBussiness;
        }

        [HttpGet]
        public IActionResult GetCivilStates()
        {
            var estadosCiviles = _estadoCivilBussines.GetEntities();
            return Ok(estadosCiviles);
        }
    }
}