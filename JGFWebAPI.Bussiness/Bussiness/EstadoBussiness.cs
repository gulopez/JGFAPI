using AutoMapper;
using JGFWebAPI.Bussiness.Interfaces;
using JGFWebAPI.Models.ViewModels;
using JGFWebAPI.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGFWebAPI.Bussiness.Bussiness
{
    public class EstadoBussiness : IGeneric<EstadoViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public EstadoBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(EstadoViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(EstadoViewModel entity)
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

        public ICollection<EstadoViewModel> GetEntities()
        {
            var estados = _fortoulContext.Estado
                          .OrderBy(e => e.Tipo)
                          .AsNoTracking()
                          .ToList();
            var estadosViewModel = new List<EstadoViewModel>();
            foreach (var item in estados)
            {
                estadosViewModel.Add(_mapper.Map<EstadoViewModel>(item));
            }
            return estadosViewModel;
        }

        public EstadoViewModel GetEntity(Guid id)
        {
            var estado = _fortoulContext.Estado
                        .Where(u => u.Id == id)
                        .AsNoTracking()
                        .FirstOrDefault();
            var estadoViewModel = _mapper.Map<EstadoViewModel>(estado);
            return estadoViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(EstadoViewModel entity)
        {
            throw new NotImplementedException();
        }

        public EstadoViewModel GetEntityByName(string name)
        {
            var estado = _fortoulContext.Estado
                        .Where(u => u.Tipo == name)
                        .AsNoTracking()
                        .FirstOrDefault();
            var estadoViewModel = _mapper.Map<EstadoViewModel>(estado);
            return estadoViewModel;
        }
    }
}
