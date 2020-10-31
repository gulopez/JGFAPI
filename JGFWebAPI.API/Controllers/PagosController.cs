using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JGFWebAPI.Bussiness.Bussiness;
using JGFWebAPI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JGFWebAPI.API.Controllers
{
    [Route("api/Pagos")]
    [ApiController]
    public class PagosController : ControllerBase
    {
        private readonly PagoBussiness _pagoMasterBussiness;
        private readonly AlumnoBussiness _alumnoBussiness;
        private readonly CarritoCompraBussiness _carritoCompraBussiness;
        private readonly PagoDetalladoBussiness _pagoDetalladoBussiness;

        public PagosController(PagoBussiness pagoMasterBussiness, AlumnoBussiness alumnoBussiness,
                                CarritoCompraBussiness carritoCompraBussiness, PagoDetalladoBussiness pagoDetalladoBussiness)
        {
            _pagoMasterBussiness = pagoMasterBussiness;
            _alumnoBussiness = alumnoBussiness;
            _carritoCompraBussiness = carritoCompraBussiness;
            _pagoDetalladoBussiness = pagoDetalladoBussiness;
        }

        [HttpGet]
        public IActionResult GetPayments()
        {
            var pagos = _pagoMasterBussiness.GetEntities();
            return Ok(pagos);
        }

        [HttpGet("Representante/{id}")]
        public IActionResult GetPaymentsByRepresentative(Guid id)
        {
            var alumnos = _alumnoBussiness.GetEntitiesByRepresentative(id, false);
            List<PagoMasterViewModel> pagoMasters = new List<PagoMasterViewModel>();
            foreach (var item in alumnos)
            {
                var pagos = _pagoMasterBussiness.GetEntitiesByStudent(item.Id);
                foreach (var pago in pagos)
                {
                    pagoMasters.Add(pago);
                }
            }
            
            return Ok(pagoMasters);
        }

        [HttpGet("Carrito")]
        public IActionResult GetShoppingCars()
        {
            var carritos = _carritoCompraBussiness.GetEntities();
            return Ok(carritos);
        }

        [HttpPost("Carrito")]
        public async Task<IActionResult> ShoppingCar(CarritoCompraViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(ModelState);
            }

            //if (_carritoCompraBussiness.ExistsEntity(vm.Id))
            //{
            //    ModelState.AddModelError("", "La compra ya se encuentra registrado");
            //    return StatusCode(404, ModelState);
            //}

            if (!_carritoCompraBussiness.CreateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo guardar la compra {vm.Alumno.PrimerNombre} {vm.Alumno.PrimerApellido}");
                return StatusCode(500, ModelState);
            }

            return Ok(vm);
        }

        [HttpGet("Carrito/Representante/{id}")]
        public IActionResult GetShoppingCarByRepresentative(Guid id)
        {
            var compras = _carritoCompraBussiness.GetEntitiesByRepresentative(id);
            return Ok(compras);
        }

        [HttpGet("Carrito/Total/{id}")]
        public IActionResult GetTotalShoppingCar(Guid id)
        {
            var compras = _carritoCompraBussiness.TotalShoppingCar(id);
            return Ok(compras);
        }

        [HttpGet("Carrito/MontoTotal/{id}")]
        public IActionResult GetTotalAmountShoppingCar(Guid id)
        {
            var montoTotal = _carritoCompraBussiness.TotalAmountShoppingCar(id);
            return Ok(montoTotal);
        }

        [HttpGet("PagoDetallado/Representante/{id}")]
        public IActionResult GetDetailsPaymentsByRepresentative(Guid id)
        {
            var pagos = _pagoDetalladoBussiness.GetEntitiesByRepresentative(id);
            return Ok(pagos);
        }

        [HttpPost("PagoDetallado")]
        public async Task<IActionResult> DetailPayment(PagoDetalladoViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(ModelState);
            }

            if (!_pagoDetalladoBussiness.CreateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo guardar el pago {vm.FormaPago.Tipo} {vm.Referencia}");
                return StatusCode(500, ModelState);
            }

            return Ok(vm);
        }

        [HttpDelete("Carrito/{id}")]
        public async Task<IActionResult> DeleteShoppingCar(Guid id)
        {
            CarritoCompraViewModel vm = new CarritoCompraViewModel();
            vm = _carritoCompraBussiness.GetEntity(id);

            if (!_carritoCompraBussiness.DeleteEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo elimianr el pago {vm.ConceptoPago} {vm.MontoPagar}");
                return StatusCode(500, ModelState);
            }

            return Ok(vm);
        }

        [HttpDelete("PagoDetallado/{id}")]
        public async Task<IActionResult> DeleteDetailPayment(Guid id)
        {
            PagoDetalladoViewModel vm = new PagoDetalladoViewModel();
            vm = _pagoDetalladoBussiness.GetEntity(id);

            if (!_pagoDetalladoBussiness.DeleteEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo eliminar el método de pago {vm.FormaPago.Tipo} {vm.Monto}");
                return StatusCode(500, ModelState);
            }

            return Ok(vm);
        }

        [HttpGet("PagoDetallado/MontoTotal/{id}")]
        public IActionResult GetTotalAmountDetailPayment(Guid id)
        {
            var montoTotal = _pagoDetalladoBussiness.TotalAmountDetailPayment(id);
            return Ok(montoTotal);
        }

        [HttpPost("PagoMaster")]
        public async Task<IActionResult> MasterPayment(PagoMasterViewModel vm)
        {
            if (vm == null)
            {
                return BadRequest(ModelState);
            }

            if (!_pagoMasterBussiness.CreateEntity(vm))
            {
                ModelState.AddModelError("", $"No se pudo guardar el pago {vm.ConceptoPago.Nombre} {vm.Monto}");
                return StatusCode(500, ModelState);
            }

            return Ok(vm);
        }
    }
}