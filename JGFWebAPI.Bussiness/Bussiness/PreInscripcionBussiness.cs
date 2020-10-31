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
    public class PreInscripcionBussiness : IGeneric<PreInscripcionViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public PreInscripcionBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(PreInscripcionViewModel entity)
        {
            entity.FechaPreInscripcion = DateTime.Now;
            entity.Actualizado = DateTime.Now;
            _fortoulContext.Add(_mapper.Map<PreInscripcion>(entity));
            return Save();
        }

        public bool DeleteEntity(PreInscripcionViewModel entity)
        {
            throw new NotImplementedException();
        }

        public bool ExistsEntity(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool ExistsEntity(Guid id)
        {
            return _fortoulContext.PreInscripcion.Any(p => p.IdAlumno == id);
        }

        public ICollection<PreInscripcionViewModel> GetEntities()
        {
            var preinscripciones = _fortoulContext.PreInscripcion
                                 .Include(a => a.Alumno)
                                 .Include(p => p.PeriodoEscolar)
                                 .Include(g => g.GradoEscolar)
                                 .Include(u => u.Usuario)
                                 .Include(e => e.Estado)
                                 .Include(r => r.Representante)
                                 .ToList();

            var preinscripcionesViewModel = new List<PreInscripcionViewModel>();
            foreach (var item in preinscripciones)
            {
                preinscripcionesViewModel.Add(_mapper.Map<PreInscripcionViewModel>(item));
            }

            return preinscripcionesViewModel;
        }

        public PreInscripcionViewModel GetEntity(Guid id)
        {
            var preinscripcion = _fortoulContext.PreInscripcion
                                 .Include(a => a.Alumno)
                                 .Include(p => p.PeriodoEscolar)
                                 .Include(g => g.GradoEscolar)
                                 .Include(u => u.Usuario)
                                 .Include(e => e.Estado)
                                 .Include(r => r.Representante)
                                 .Where(a => a.Id == id)
                                 .FirstOrDefault();

            var preinscripcionViewModel = _mapper.Map<PreInscripcionViewModel>(preinscripcion);
            return preinscripcionViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(PreInscripcionViewModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
