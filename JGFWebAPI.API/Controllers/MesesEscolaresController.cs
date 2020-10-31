using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/MesesEscolares")]
    [ApiController]
    public class MesesEscolaresController : ControllerBase
    {
        private readonly MesEscolarBussiness _MesBussiness;

        public MesesEscolaresController(MesEscolarBussiness mesEscolarBussiness)
        {
            _MesBussiness = mesEscolarBussiness;
        }

        [HttpGet]
        public IActionResult GetSchoolMonths()
        {
            var meses = _MesBussiness.GetEntities();
            return Ok(meses);
        }
    }
}