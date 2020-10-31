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
    public class PerfilBussiness : IGeneric<PerfilViewModel>
    {
        private readonly FortoulContext _webFortoulContext;
        private readonly IMapper _mapper;

        public PerfilBussiness(FortoulContext webFortoulContext, IMapper mapper)
        {
            _webFortoulContext = webFortoulContext;
            _mapper = mapper;
        }

        public bool CreateEntity(PerfilViewModel entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Estado = true;
            _webFortoulContext.Add(_mapper.Map<Perfil>(entity));
            return Save();
        }

        public bool DeleteEntity(PerfilViewModel entity)
        {
            _webFortoulContext.Remove(_mapper.Map<Perfil>(entity));
            return Save();
        }

        public bool ExistsEntity(string keyword)
        {
            return _webFortoulContext.Perfil.Any(u => u.Nombre.ToLower().Trim() == keyword.ToLower().Trim());
        }

        public bool ExistsEntity(Guid id)
        {
            return _webFortoulContext.Perfil.Any(u => u.Id == id);
        }

        public ICollection<PerfilViewModel> GetEntities()
        {
            var perfiles = _webFortoulContext.Perfil.OrderBy(u => u.Nombre).ToList();
            var perfilesViewModel = new List<PerfilViewModel>();
            foreach (var item in perfiles)
            {
                perfilesViewModel.Add(_mapper.Map<PerfilViewModel>(item));
            }
            return perfilesViewModel;
        }

        public PerfilViewModel GetEntity(Guid id)
        {
            var perfil = _webFortoulContext.Perfil.Any(u => u.Id == id);
            var perfilViewModel = _mapper.Map<PerfilViewModel>(perfil);
            return perfilViewModel;
        }

        public bool Save()
        {
            return _webFortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(PerfilViewModel entity)
        {
            _webFortoulContext.Update(_mapper.Map<Perfil>(entity));
            return Save();
        }
    }
}
