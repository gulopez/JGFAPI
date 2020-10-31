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
    [Route("api/PeriodosEscolares")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class PeriodosEscolaresController : ControllerBase
    {
        private readonly PeriodoEscolarBussiness _periodoEscolarBussiness;

        public PeriodosEscolaresController(PeriodoEscolarBussiness periodoEscolarBussiness)
        {
            _periodoEscolarBussiness = periodoEscolarBussiness;
        }

        [HttpGet]
        public IActionResult GetSchoolPeriods()
        {
            var periodosEscolares = _periodoEscolarBussiness.GetEntities();
            return Ok(periodosEscolares);
        }
    }
}