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
    public class PeriodoEscolarBussiness : IGeneric<PeriodoEscolarViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public PeriodoEscolarBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(PeriodoEscolarViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(PeriodoEscolarViewModel entity)
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

        public ICollection<PeriodoEscolarViewModel> GetEntities()
        {
            var periodosEscolares = _fortoulContext.PeriodoEscolar
                                    .OrderBy(a => a.Periodo)
                                    .ToList();
            var periodosEscolaresViewModel = new List<PeriodoEscolarViewModel>();
            foreach (var item in periodosEscolares)
            {
                periodosEscolaresViewModel.Add(_mapper.Map<PeriodoEscolarViewModel>(item));
            }
            return periodosEscolaresViewModel;
        }

        public PeriodoEscolarViewModel GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(PeriodoEscolarViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
