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
    public class SeccionBussiness : IGeneric<SeccionViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public SeccionBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(SeccionViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(SeccionViewModel entity)
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

        public ICollection<SeccionViewModel> GetEntities()
        {
            var secciones = _fortoulContext.Seccion
                            .OrderBy(x => x.Orden);
            var seccionesViewModel = new List<SeccionViewModel>();
            foreach (var item in secciones)
            {
                seccionesViewModel.Add(_mapper.Map<SeccionViewModel>(item));
            }
            return seccionesViewModel;
        }

        public SeccionViewModel GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(SeccionViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
