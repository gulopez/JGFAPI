using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/FormasDePagos")]
    [ApiController]
    public class FormasDePagosController : ControllerBase
    {
        private readonly FormaDePagoBussiness _formaDePagoBussiness;

        public FormasDePagosController(FormaDePagoBussiness formaDePagoBussiness)
        {
            _formaDePagoBussiness = formaDePagoBussiness;
        }

        [HttpGet]
        public IActionResult GetPaymentMethod()
        {
            var pagos = _formaDePagoBussiness.GetEntities();
            return Ok(pagos);
        }
    }
}