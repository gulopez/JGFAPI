using AutoMapper;
using JGFWebAPI.Bussiness.Interfaces;
using JGFWebAPI.Models.ViewModels;
using JGFWebAPI.Repository.Context;
using JGFWebAPI.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JGFWebAPI.Bussiness.Bussiness
{
    public class PagoBussiness : IGeneric<PagoMasterViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public PagoBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(PagoMasterViewModel entity)
        {
            _fortoulContext.PagoMaster.Add(_mapper.Map<PagoMaster>(entity));
            return Save();
        }

        public bool DeleteEntity(PagoMasterViewModel entity)
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

        public ICollection<PagoMasterViewModel> GetEntities()
        {
            var pagos = _fortoulContext.PagoMaster
                        .Include(a => a.Alumno)
                        .Include(p => p.PeriodoEscolar)
                        .Include(cp => cp.ConceptoPago)
                        .Include(me => me.MesEscolar)
                        .OrderByDescending(pm => pm.FechaPago)
                        .ToList();
            var pagosViewModel = new List<PagoMasterViewModel>();
            foreach (var item in pagos)
            {
                pagosViewModel.Add(_mapper.Map<PagoMasterViewModel>(item));
            }
            return pagosViewModel;
        }

        public ICollection<PagoMasterViewModel> GetEntitiesByStudent(Guid id)
        {
            var pagos = _fortoulContext.PagoMaster
                        .Include(a => a.Alumno)
                        .Include(p => p.PeriodoEscolar)
                        .Include(cp => cp.ConceptoPago)
                        .Include(me => me.MesEscolar)
                        .Where(pm => pm.IdAlumno == id)
                        .OrderByDescending(pm => pm.FechaPago)
                        .ToList();
            var pagosViewModel = new List<PagoMasterViewModel>();
            foreach (var item in pagos)
            {
                pagosViewModel.Add(_mapper.Map<PagoMasterViewModel>(item));
            }
            return pagosViewModel;
        }

        public PagoMasterViewModel GetEntity(Guid id)
        {
            var pago = _fortoulContext.PagoMaster
                        .Include(a => a.Alumno)
                        .Include(p => p.PeriodoEscolar)
                        .Include(cp => cp.ConceptoPago)
                        .Include(me => me.MesEscolar)
                        .Where(a => a.Id == id)
                        .FirstOrDefault();
            var pagoViewModel = _mapper.Map<PagoMasterViewModel>(pago);
            return pagoViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(PagoMasterViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
