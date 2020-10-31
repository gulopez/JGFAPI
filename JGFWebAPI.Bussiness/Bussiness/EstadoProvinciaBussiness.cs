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
    public class EstadoProvinciaBussiness : IGeneric<EstadoProvinciaViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public EstadoProvinciaBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(EstadoProvinciaViewModel entity)
        {
            _fortoulContext.Add(_mapper.Map<EstadoProvincia>(entity));
            return Save();
        }

        public bool DeleteEntity(EstadoProvinciaViewModel entity)
        {
            _fortoulContext.Remove(_mapper.Map<EstadoProvincia>(entity));
            return Save();
        }

        public bool ExistsEntity(string keyword)
        {
            return _fortoulContext.EstadoProvincia.Any(s => s.Nombre.ToLower().Trim() == keyword.ToLower().Trim());
        }

        public bool ExistsEntity(Guid id)
        {
            return _fortoulContext.EstadoProvincia.Any(s => s.Id == id);
        }

        public ICollection<EstadoProvinciaViewModel> GetEntities()
        {
            var estados = _fortoulContext.EstadoProvincia
                          .Include(p => p.Pais)
                          .OrderBy(s => s.Nombre)
                          .ToList();
            var estadosViewModel = new List<EstadoProvinciaViewModel>();
            foreach (var item in estados)
            {
                estadosViewModel.Add(_mapper.Map<EstadoProvinciaViewModel>(item));
            }
            return estadosViewModel;
        }

        public ICollection<EstadoProvinciaViewModel> GetEntitiesByCountry(Guid id)
        {
            var estados = _fortoulContext.EstadoProvincia
                          .Include(p => p.Pais)
                          .Where(s => s.IdPais == id)
                          .OrderBy(s => s.Nombre)
                          .ToList();
            var estadosViewModel = new List<EstadoProvinciaViewModel>();
            foreach (var item in estados)
            {
                estadosViewModel.Add(_mapper.Map<EstadoProvinciaViewModel>(item));
            }
            return estadosViewModel;
        }

        public EstadoProvinciaViewModel GetEntity(Guid id)
        {
            var estado = _fortoulContext.EstadoProvincia
                         .Include(p => p.Pais)
                         .Where(s => s.Id == id)
                         .FirstOrDefault();
            var estadoViewModel = _mapper.Map<EstadoProvinciaViewModel>(estado);
            return estadoViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(EstadoProvinciaViewModel entity)
        {
            _fortoulContext.Update(_mapper.Map<EstadoProvincia>(entity));
            return Save();
        }

        public EstadoProvinciaViewModel GetEntityByName(string name)
        {
            var estado = _fortoulContext.EstadoProvincia
                         .Include(p => p.Pais)
                         .Where(s => s.Nombre == name)
                         .FirstOrDefault();
            var estadoViewModel = _mapper.Map<EstadoProvinciaViewModel>(estado);
            return estadoViewModel;
        }
    }
}
