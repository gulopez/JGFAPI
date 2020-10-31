using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/ConceptosPago")]
    [ApiController]
    public class ConceptosPagoController : ControllerBase
    {
        private readonly ConceptoPagoBussiness _conceptoPagoBussiness;

        public ConceptosPagoController(ConceptoPagoBussiness conceptoPagoBussiness)
        {
            _conceptoPagoBussiness = conceptoPagoBussiness;
        }

        [HttpGet]
        public IActionResult GetSchoolMonths()
        {
            var conceptos = _conceptoPagoBussiness.GetEntities();
            return Ok(conceptos);
        }
    }
}