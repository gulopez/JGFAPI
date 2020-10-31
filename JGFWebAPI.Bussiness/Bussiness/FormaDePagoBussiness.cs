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
    public class FormaDePagoBussiness : IGeneric<FormaPagoViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public FormaDePagoBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(FormaPagoViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(FormaPagoViewModel entity)
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

        public ICollection<FormaPagoViewModel> GetEntities()
        {
            var pagos = _fortoulContext.FormaPago
                          .OrderBy(a => a.Tipo)
                          .ToList();
            var pagosViewModel = new List<FormaPagoViewModel>();
            foreach (var item in pagos)
            {
                pagosViewModel.Add(_mapper.Map<FormaPagoViewModel>(item));
            }
            return pagosViewModel;
        }

        public FormaPagoViewModel GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(FormaPagoViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
