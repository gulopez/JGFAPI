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
    public class DatoMedicoBussiness : IGeneric<DatosMedicosViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public DatoMedicoBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(DatosMedicosViewModel entity)
        {
            _fortoulContext.Add(_mapper.Map<DatosMedicos>(entity));
            return Save();
        }

        public bool DeleteEntity(DatosMedicosViewModel entity)
        {
            _fortoulContext.Remove(_mapper.Map<DatosMedicos>(entity));
            return Save();
        }

        public bool ExistsEntity(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool ExistsEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<DatosMedicosViewModel> GetEntities()
        {
            var datosMedicos = _fortoulContext.DatosMedicos
                                .ToList();
            var datosMedicosViewModel = new List<DatosMedicosViewModel>();
            foreach (var item in datosMedicos)
            {
                datosMedicosViewModel.Add(_mapper.Map<DatosMedicosViewModel>(item));
            }
            return datosMedicosViewModel;
        }

        public DatosMedicosViewModel GetEntity(Guid id)
        {
            var datoMedico = _fortoulContext.DatosMedicos
                            .Where(u => u.Id == id)
                            .FirstOrDefault();
            var datoMedicoViewModel = _mapper.Map<DatosMedicosViewModel>(datoMedico);
            return datoMedicoViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(DatosMedicosViewModel entity)
        {
            _fortoulContext.Update(_mapper.Map<DatosMedicos>(entity));
            return Save();
        }
    }
}
