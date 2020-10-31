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
    [Route("api/GradosEscolares")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class GradosEscolaresController : ControllerBase
    {
        private readonly GradoEscolarBussiness _gradoEscolarBussiness;

        public GradosEscolaresController(GradoEscolarBussiness gradoEscolarBussiness)
        {
            _gradoEscolarBussiness = gradoEscolarBussiness;
        }

        [HttpGet]
        public IActionResult GetSchoolGrades()
        {
            var gradosEscolares = _gradoEscolarBussiness.GetEntities();
            return Ok(gradosEscolares);
        }
    }
}