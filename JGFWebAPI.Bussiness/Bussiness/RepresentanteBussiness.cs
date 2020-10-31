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
    public class RepresentanteBussiness : IGeneric<RepresentanteViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;

        public RepresentanteBussiness(FortoulContext fortoulContext, IMapper mapper)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(RepresentanteViewModel entity)
        {
            _fortoulContext.Add(_mapper.Map<Representante>(entity));
            return Save();
        }

        public bool DeleteEntity(RepresentanteViewModel entity)
        {
            _fortoulContext.Remove(_mapper.Map<Representante>(entity));
            return Save();
        }

        public bool ExistsEntity(string keyword)
        {
            return _fortoulContext.Representante.Any(u => u.CedulaRepresentante == keyword);
        }

        public bool ExistsEntity(Guid id)
        {
            return _fortoulContext.Representante.Any(r => r.Id == id);
        }

        public ICollection<RepresentanteViewModel> GetEntities()
        {
            var representantes = _fortoulContext.Representante
                                 .Include(a => a.Direccion)
                                 .Include(e => e.Direccion.EstadoProvincia)
                                 .OrderBy(r => r.PrimerApellido)
                                 .ToList();
            var representantesViewModel = new List<RepresentanteViewModel>();
            foreach (var item in representantes)
            {
                representantesViewModel.Add(_mapper.Map<RepresentanteViewModel>(item));
            }
            return representantesViewModel;
        }

        public RepresentanteViewModel GetEntity(Guid id)
        {
            var representante = _fortoulContext.Representante
                                .Include(a => a.Direccion)
                                .Include(e => e.Direccion.EstadoProvincia)
                                .Where(r => r.Id == id)
                                .FirstOrDefault();
            var representanteViewModel = _mapper.Map<RepresentanteViewModel>(representante);
            return representanteViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(RepresentanteViewModel entity)
        {
            _fortoulContext.Update(_mapper.Map<Representante>(entity));
            return Save();
        }

        public RepresentanteViewModel GetEntityByCardId(string cardId)
        {
            var representante = _fortoulContext.Representante
                                .Include(a => a.Direccion)
                                .Include(e => e.Direccion.EstadoProvincia)
                                .Include(e => e.Direccion.EstadoProvincia.Pais)
                                .Where(r => r.CedulaRepresentante == cardId)
                                .FirstOrDefault();
            var representanteViewModel = _mapper.Map<RepresentanteViewModel>(representante);
            return representanteViewModel;
        }
    }
}
