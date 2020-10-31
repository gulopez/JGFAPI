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
    public class MesEscolarBussiness : IGeneric<MesEscolarViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public MesEscolarBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(MesEscolarViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEntity(MesEscolarViewModel entity)
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

        public ICollection<MesEscolarViewModel> GetEntities()
        {
            var meses = _fortoulContext.MesEscolar
                        .OrderBy(m => m.Numero)
                        .ToList();

            var mesesViewModel = new List<MesEscolarViewModel>();
            foreach (var item in meses)
            {
                mesesViewModel.Add(_mapper.Map<MesEscolarViewModel>(item));
            }
            return mesesViewModel;
        }

        public MesEscolarViewModel GetEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(MesEscolarViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
