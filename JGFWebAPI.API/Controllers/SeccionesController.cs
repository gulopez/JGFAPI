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
    [Route("api/Secciones")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class SeccionesController : ControllerBase
    {
        private readonly SeccionBussiness _seccionBussiness;

        public SeccionesController(SeccionBussiness seccionBussiness)
        {
            _seccionBussiness = seccionBussiness;
        }

        [HttpGet]
        public IActionResult GetSections()
        {
            var secciones = _seccionBussiness.GetEntities();
            return Ok(secciones);
        }
    }
}