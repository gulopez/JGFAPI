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
    public class DatoFamiliarBussiness : IGeneric<DatosFamiliaresViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public DatoFamiliarBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(DatosFamiliaresViewModel entity)
        {
            _fortoulContext.Add(_mapper.Map<DatosFamiliares>(entity));
            return Save();
        }

        public bool DeleteEntity(DatosFamiliaresViewModel entity)
        {
            _fortoulContext.Remove(_mapper.Map<DatosFamiliares>(entity));
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

        public ICollection<DatosFamiliaresViewModel> GetEntities()
        {
            var datosFamiliares = _fortoulContext.DatosFamiliares
                                  .ToList();
            var datosFamiliaresViewModel = new List<DatosFamiliaresViewModel>();
            foreach (var item in datosFamiliares)
            {
                datosFamiliaresViewModel.Add(_mapper.Map<DatosFamiliaresViewModel>(item));
            }
            return datosFamiliaresViewModel;
        }

        public DatosFamiliaresViewModel GetEntity(Guid id)
        {
            var datoFamiliar = _fortoulContext.DatosFamiliares
                                .Where(u => u.Id == id)
                                .FirstOrDefault();
            var datoFamiliarViewModel = _mapper.Map<DatosFamiliaresViewModel>(datoFamiliar);
            return datoFamiliarViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(DatosFamiliaresViewModel entity)
        {
            _fortoulContext.Update(_mapper.Map<DatosFamiliares>(entity));
            return Save();
        }
    }
}
