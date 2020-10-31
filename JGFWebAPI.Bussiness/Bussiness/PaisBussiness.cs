using AutoMapper;
using JGFWebAPI.Bussiness.Interfaces;
using JGFWebAPI.Models.ViewModels;
using JGFWebAPI.Repository.Context;
using JGFWebAPI.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGFWebAPI.Bussiness.Bussiness
{
    public class PaisBussiness : IGeneric<PaisViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public PaisBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(PaisViewModel entity)
        {
            _fortoulContext.Add(_mapper.Map<Pais>(entity));
            return Save();
        }

        public bool DeleteEntity(PaisViewModel entity)
        {
            _fortoulContext.Remove(_mapper.Map<Pais>(entity));
            return Save();
        }

        public bool ExistsEntity(string keyword)
        {
            return _fortoulContext.Pais.Any(c => c.Nombre.ToLower().Trim() == keyword.ToLower().Trim());
        }

        public bool ExistsEntity(Guid id)
        {
            return _fortoulContext.Pais.Any(c => c.Id == id);
        }

        public ICollection<PaisViewModel> GetEntities()
        {
            var paises = _fortoulContext.Pais
                          .OrderBy(c => c.Nombre)
                          .ToList();
            var paisesViewModel = new List<PaisViewModel>();
            foreach (var item in paises)
            {
                paisesViewModel.Add(_mapper.Map<PaisViewModel>(item));
            }
            return paisesViewModel;
        }

        public PaisViewModel GetEntity(Guid id)
        {
            var pais = _fortoulContext.Pais
                         .Where(c => c.Id == id)
                         .FirstOrDefault();
            var paisViewModel = _mapper.Map<PaisViewModel>(pais);
            return paisViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(PaisViewModel entity)
        {
            _fortoulContext.Update(_mapper.Map<Pais>(entity));
            return Save();
        }

        public PaisViewModel GetEntityByName(string name)
        {
            var pais = _fortoulContext.Pais
                        .Where(s => s.Nombre == name)
                        .FirstOrDefault();
            var paisViewModel = _mapper.Map<PaisViewModel>(pais);
            return paisViewModel;
        }
    }
}
