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
    public class DireccionBussiness : IGeneric<DireccionViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public DireccionBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(DireccionViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(DireccionViewModel entity)
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

        public ICollection<DireccionViewModel> GetEntities()
        {
            throw new NotImplementedException();
        }

        public DireccionViewModel GetEntity(Guid id)
        {
            var direccion = _fortoulContext.Direccion
                            .Where(u => u.Id == id)
                            .FirstOrDefault();
            var direccionViewModel = _mapper.Map<DireccionViewModel>(direccion);
            return direccionViewModel;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(DireccionViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
