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
    public class ConceptoPagoBussiness : IGeneric<ConceptoPagoViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public ConceptoPagoBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(ConceptoPagoViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(ConceptoPagoViewModel entity)
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

        public ICollection<ConceptoPagoViewModel> GetEntities()
        {
            var conceptos = _fortoulContext.ConceptoPago
                            .ToList();

            var conceptosViewModel = new List<ConceptoPagoViewModel>();
            foreach (var item in conceptos)
            {
                conceptosViewModel.Add(_mapper.Map<ConceptoPagoViewModel>(item));
            }
            return conceptosViewModel;
        }

        public ConceptoPagoViewModel GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(ConceptoPagoViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
