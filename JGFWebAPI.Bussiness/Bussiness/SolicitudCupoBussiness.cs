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
    public class SolicitudCupoBussiness : IGeneric<SolicitudCupoViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public SolicitudCupoBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(SolicitudCupoViewModel entity)
        {
            _fortoulContext.Add(_mapper.Map<SolicitudCupo>(entity));
            return Save();
        }

        public bool DeleteEntity(SolicitudCupoViewModel entity)
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

        public SolicitudCupoViewModel GetEntitiesByStudent(Guid id)
        {
            var cupo = _fortoulContext.SolicitudCupo
                       .Include(p => p.PeriodoEscolar)
                       .Include(g => g.GradoEscolar)
                       .Include(e => e.Estado)
                       .Where(u => u.IdAlumno == id)
                       .FirstOrDefault();
            var cupoViewModel = _mapper.Map<SolicitudCupoViewModel>(cupo);
            return cupoViewModel;
        }

        public ICollection<SolicitudCupoViewModel> GetEntities()
        {
            var cupos = _fortoulContext.SolicitudCupo
                        .Include(p => p.PeriodoEscolar)
                        .Include(g => g.GradoEscolar)
                        .Include(e => e.Estado)
                        .OrderBy(a => a.PrimerApellido)
                        .ToList();
            var cuposViewModel = new List<SolicitudCupoViewModel>();
            foreach (var item in cupos)
            {
                cuposViewModel.Add(_mapper.Map<SolicitudCupoViewModel>(item));
            }
            return cuposViewModel;
        }

        public ICollection<SolicitudCupoViewModel> GetEntitiesByUsuario(Guid id)
        {
            var cupos = _fortoulContext.SolicitudCupo
                        .Include(p => p.PeriodoEscolar)
                        .Include(g => g.GradoEscolar)
                        .Include(e => e.Estado)
                        .Where(s => s.IdUsuario == id)
                        .OrderBy(a => a.PrimerApellido)
                        .ToList();
            var cuposViewModel = new List<SolicitudCupoViewModel>();
            foreach (var item in cupos)
            {
                cuposViewModel.Add(_mapper.Map<SolicitudCupoViewModel>(item));
            }
            return cuposViewModel;
        }

        public SolicitudCupoViewModel GetEntity(Guid id)
        {
            var cupo = _fortoulContext.SolicitudCupo
                       .Include(p => p.PeriodoEscolar)
                       .Include(g => g.GradoEscolar)
                       .Include(e => e.Estado)
                       .Where(u => u.Id == id)
                       .FirstOrDefault();
            var cupoViewModel = _mapper.Map<SolicitudCupoViewModel>(cupo);
            return cupoViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(SolicitudCupoViewModel entity)
        {
            _fortoulContext.Update(_mapper.Map<SolicitudCupo>(entity));
            return Save();
        }
    }
}
