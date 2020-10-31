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
    public class GradoEscolarBussiness : IGeneric<GradoEscolarViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public GradoEscolarBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(GradoEscolarViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(GradoEscolarViewModel entity)
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

        public ICollection<GradoEscolarViewModel> GetEntities()
        {
            var gradosEscolares = _fortoulContext.GradoEscolar
                                  .OrderBy(a => a.Orden)
                                  .ToList();
            var gradosEscolaresViewModel = new List<GradoEscolarViewModel>();
            foreach (var item in gradosEscolares)
            {
                gradosEscolaresViewModel.Add(_mapper.Map<GradoEscolarViewModel>(item));
            }
            return gradosEscolaresViewModel;
        }

        public GradoEscolarViewModel GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(GradoEscolarViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
