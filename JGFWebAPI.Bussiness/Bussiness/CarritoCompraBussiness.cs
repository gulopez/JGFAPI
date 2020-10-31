using AutoMapper;
using JGFWebAPI.Bussiness.Interfaces;
using JGFWebAPI.Models.ViewModels;
using JGFWebAPI.Repository.Context;
using JGFWebAPI.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGFWebAPI.Bussiness.Bussiness
{
    public class CarritoCompraBussiness : IGeneric<CarritoCompraViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public CarritoCompraBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(CarritoCompraViewModel entity)
        {
            _fortoulContext.Add(_mapper.Map<CarritoCompra>(entity));
            return Save();
        }

        public bool DeleteEntity(CarritoCompraViewModel entity)
        {
            _fortoulContext.Remove(_mapper.Map<CarritoCompra>(entity));
            return Save();
        }

        public bool ExistsEntity(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool ExistsEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<CarritoCompraViewModel> GetEntities()
        {
            throw new NotImplementedException();
        }

        public CarritoCompraViewModel GetEntity(Guid id)
        {
            var carrito = _fortoulContext.CarritoCompra
                          .Include(a => a.Alumno)
                          .Include(p => p.PeriodoEscolar)
                          .Include(c => c.ConceptoPago)
                          .Include(m => m.MesEscolar)
                          .Where(a => a.Id == id)
                          .AsNoTracking()
                          .FirstOrDefault();
            var carritoViewModel = _mapper.Map<CarritoCompraViewModel>(carrito);
            return carritoViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(CarritoCompraViewModel entity)
        {
            _fortoulContext.Update(_mapper.Map<CarritoCompra>(entity));
            return Save();
        }

        public object GetEntitiesByRepresentative(Guid id)
        {
            List<Guid> idsAlumnos = _fortoulContext.Alumno
                                     .Where(r => r.IdRepresentante == id || r.IdPadre == id || r.IdMadre == id)
                                     .Select(a => a.Id)
                                     .ToList();

            var carritos = _fortoulContext.CarritoCompra
                          .Include(a => a.Alumno)
                          .Include(p => p.PeriodoEscolar)
                          .Include(c => c.ConceptoPago)
                          .Include(m => m.MesEscolar)
                          .Where(a => idsAlumnos.Contains(a.IdAlumno))
                          .AsNoTracking()
                          .ToList();
            var carritosViewModel = new List<CarritoCompraViewModel>();
            foreach (var item in carritos)
            {
                carritosViewModel.Add(_mapper.Map<CarritoCompraViewModel>(item));
            }
            return carritosViewModel;
        }

        public int TotalShoppingCar(Guid id)
        {
            List<Guid> idsAlumnos = _fortoulContext.Alumno
                                     .Where(r => r.IdRepresentante == id || r.IdPadre == id || r.IdMadre == id)
                                     .Select(a => a.Id)
                                     .ToList();

            var carritos = _fortoulContext.CarritoCompra
                          .Where(a => idsAlumnos.Contains(a.IdAlumno))
                          .AsNoTracking()
                          .ToList();
            return carritos.Count;
        }

        public object TotalAmountShoppingCar(Guid id)
        {
            List<Guid> idsAlumnos = _fortoulContext.Alumno
                                     .Where(r => r.IdRepresentante == id || r.IdPadre == id || r.IdMadre == id)
                                     .Select(a => a.Id)
                                     .ToList();

            var carritos = _fortoulContext.CarritoCompra
                          .Where(a => idsAlumnos.Contains(a.IdAlumno))
                          .AsNoTracking()
                          .ToList();

            decimal monto = 0;
            foreach (var item in carritos)
            {
                monto += item.MontoPagar;
            }
            return monto;
        }
    }
}
