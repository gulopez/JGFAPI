using AutoMapper;
using JGFWebAPI.Bussiness.Interfaces;
using JGFWebAPI.Models.ViewModels;
using JGFWebAPI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGFWebAPI.Bussiness.Bussiness
{
    public class EstadoCivilBussiness : IGeneric<EstadoCivilViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public EstadoCivilBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(EstadoCivilViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(EstadoCivilViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool ExistsEntity(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool ExistsEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<EstadoCivilViewModel> GetEntities()
        {
            var estados = _fortoulContext.EstadoCivil
                          .OrderBy(a => a.Nombre)
                          .ToList();
            var estadosViewModel = new List<EstadoCivilViewModel>();
            foreach (var item in estados)
            {
                estadosViewModel.Add(_mapper.Map<EstadoCivilViewModel>(item));
            }
            return estadosViewModel;
        }

        public EstadoCivilViewModel GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(EstadoCivilViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
