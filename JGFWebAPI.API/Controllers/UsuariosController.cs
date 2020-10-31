using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using JGFWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/Usuarios")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioBussiness _usuariosBussiness;

        public UsuariosController(UsuarioBussiness usuarioBussiness)
        {
            _usuariosBussiness = usuarioBussiness;
        }

        [HttpGet("Login")]
        public IActionResult DoLogin(string mail, string password)
        {
            var usuario = _usuariosBussiness.DoLogin(mail, password);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var usuarios = _usuariosBussiness.GetEntities();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            var usuario = _usuariosBussiness.GetEntity(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpGet("Cedula/{id}")]
        public IActionResult GetUserByCardId(string id)
        {
            var usuario = _usuariosBussiness.GetEntity(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpGet("Correo/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            var usuario = _usuariosBussiness.GetEntityByEmail(email);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UsuarioViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(ModelState);
            }

            if (_usuariosBussiness.ExistsEntity(vm.Correo))
            {
                ModelState.AddModelError("", "El correo ya se encuentra registrado");
                return StatusCode(404, ModelState);
            }

            if (!_usuariosBussiness.CreateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo guardar el registro {vm.Correo}");
                return StatusCode(500, ModelState);
            }

            return Ok(vm);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(Guid id, [FromBody] UsuarioViewModel vm)
        {
            if (vm == null || vm.Id != id)
            {
                return BadRequest(ModelState);
            }

            if (!_usuariosBussiness.UpdateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo actualizar el registro {vm.Correo}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            if (!_usuariosBussiness.ExistsEntity(id))
            {
                return NotFound();
            }

            var usuario = _usuariosBussiness.GetEntity(id);

            if (!_usuariosBussiness.UpdateEntity(usuario))
            {
                ModelState.AddModelError("", $"No se pudo actualizar el registro {usuario.Correo}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpPost("ConfirmMail")]
        public IActionResult ConfirmMail([FromBody] UsuarioViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(ModelState);
            }

            if (!_usuariosBussiness.ExistsEntity(vm.Id))
            {
                return NotFound();
            }

            vm.Estado = true;

            if (!_usuariosBussiness.UpdateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo confirmar el correo {vm.Correo}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("ValidateMail")]
        public IActionResult ValidateMail(string mail)
        {
            if (!_usuariosBussiness.ExistsEntity(mail))
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword([FromBody] UsuarioViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(ModelState);
            }

            if (!_usuariosBussiness.UpdateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo cambiar la contraseña");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}