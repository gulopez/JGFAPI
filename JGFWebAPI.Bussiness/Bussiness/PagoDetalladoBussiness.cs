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
    public class PagoDetalladoBussiness : IGeneric<PagoDetalladoViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public PagoDetalladoBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(PagoDetalladoViewModel entity)
        {
            _fortoulContext.Add(_mapper.Map<PagoDetallado>(entity));
            return Save();
        }

        public bool DeleteEntity(PagoDetalladoViewModel entity)
        {
            _fortoulContext.Remove(_mapper.Map<PagoDetallado>(entity));
            return Save();
        }

        public bool ExistsEntity(string keyword)
        {
            return _fortoulContext.PagoDetallado.Any(pd => pd.Referencia == keyword);
        }

        public bool ExistsEntity(Guid id)
        {
            throw new NotImplementedException();
        }

        public ICollection<PagoDetalladoViewModel> GetEntities()
        {
            var pagosDetallados = _fortoulContext.PagoDetallado
                                  .Include(pm => pm.PagoMaster)
                                  .Include(fp => fp.FormaPago)
                                  .AsNoTracking()
                                  .ToList();
            var pagosDetalladosViewModel = new List<PagoDetalladoViewModel>();
            foreach (var item in pagosDetallados)
            {
                pagosDetalladosViewModel.Add(_mapper.Map<PagoDetalladoViewModel>(item));
            }
            return pagosDetalladosViewModel;
        }

        public PagoDetalladoViewModel GetEntity(Guid id)
        {
            var pagoDetallado = _fortoulContext.PagoDetallado
                                .Include(pm => pm.PagoMaster)
                                .Include(fp => fp.FormaPago)
                                .Where(pd => pd.Id == id)
                                .AsNoTracking()
                                .FirstOrDefault();
            var pagoDetalladoViewModel = _mapper.Map<PagoDetalladoViewModel>(pagoDetallado);
            return pagoDetalladoViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;        
        }

        public bool UpdateEntity(PagoDetalladoViewModel entity)
        {
            _fortoulContext.Update(_mapper.Map<PagoDetallado>(entity));
            return Save();
        }

        public object GetEntitiesByRepresentative(Guid id)
        {
            var pagos = _fortoulContext.PagoDetallado
                        .Include(pm => pm.PagoMaster)
                        .Include(fp => fp.FormaPago)
                        .Where(pd => pd.IdRepresentante == id)
                        .AsNoTracking()
                        .ToList();
            var pagosViewModel = new List<PagoDetalladoViewModel>();
            foreach (var item in pagos)
            {
                pagosViewModel.Add(_mapper.Map<PagoDetalladoViewModel>(item));
            }
            return pagosViewModel;
        }

        public object TotalAmountDetailPayment(Guid id)
        {
            var pagos = _fortoulContext.PagoDetallado
                        .Include(pm => pm.PagoMaster)
                        .Include(fp => fp.FormaPago)
                        .Where(pd => pd.IdRepresentante == id)
                        .AsNoTracking()
                        .ToList();

            decimal monto = 0;
            foreach (var item in pagos)
            {
                monto += item.Monto;
            }
            return monto;
        }
    }
}
