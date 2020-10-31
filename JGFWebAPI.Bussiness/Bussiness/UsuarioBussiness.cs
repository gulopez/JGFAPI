using AutoMapper;
using JGFWebAPI.Bussiness.Interfaces;
using JGFWebAPI.Bussiness.Services;
using JGFWebAPI.Models.ViewModels;
using JGFWebAPI.Repository.Context;
using JGFWebAPI.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;


namespace JGFWebAPI.Bussiness.Bussiness
{
    public class UsuarioBussiness : IGeneric<UsuarioViewModel>
    {
        private readonly FortoulContext _fortoulContext;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public UsuarioBussiness(FortoulContext fortoulContext, IMapper mapper, ILogger<UsuarioBussiness> logger)
        {
            _fortoulContext = fortoulContext;
            _mapper = mapper;
            _logger = logger;
        }

        public bool CreateEntity(UsuarioViewModel entity)
        {
            entity.Id = Guid.NewGuid();
            entity.Estado = true;
            entity.SolicitarClave = false;
            if (entity.IdPerfil == Guid.Empty)
            {
                entity.IdPerfil = _fortoulContext.Perfil.Where(p => p.Nombre == "Representante").Select(x => x.Id).FirstOrDefault();
            }
            _fortoulContext.Add(_mapper.Map<Usuario>(entity));

            bool IsSaved = Save();

            if (IsSaved)
            {
                try
                {
                    EmailBodyConfirm emailBody = new EmailBodyConfirm();
                    string bodyMessage = emailBody.MessageBodyConfirm(entity);
                    EmailService emailService = new EmailService();
                    emailService.SendEmailAsync(entity.Correo, "Alta de Registro", bodyMessage);
                }
                catch(Exception ex)
                {
                    //TODO:
                    //Log Exception and store the email in DB to resend later

                    _logger.LogError("Error Sending Email:" + ex.Message);
                }
               
            }
            return IsSaved;
        }

        public bool DeleteEntity(UsuarioViewModel entity)
        {
            _fortoulContext.Remove(_mapper.Map<Usuario>(entity));
            return Save();
        }

        public bool ExistsEntity(string keyword)
        {
            return _fortoulContext.Usuario.Any(u => u.Correo.ToLower().Trim() == keyword.ToLower().Trim());
        }

        public bool ExistsEntity(Guid id)
        {
            return _fortoulContext.Usuario.Any(u => u.Id == id);
        }

        public ICollection<UsuarioViewModel> GetEntities()
        {
            var usuarios = _fortoulContext.Usuario
                           .Include(p => p.Perfil)
                           .OrderBy(u => u.Correo)
                           .ToList();
            var usuariosViewModel = new List<UsuarioViewModel>();
            foreach (var item in usuarios)
            {
                usuariosViewModel.Add(_mapper.Map<UsuarioViewModel>(item));
            }
            return usuariosViewModel;
        }

        public UsuarioViewModel GetEntity(Guid id)
        {
            var usuario = _fortoulContext.Usuario
                          .Include(p => p.Perfil)
                          .Where(u => u.Id == id)
                          .FirstOrDefault();
            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);
            return usuarioViewModel;
        }

        public UsuarioViewModel GetEntity(string id)
        {
            var usuario = _fortoulContext.Usuario
                          .Include(p => p.Perfil)
                          .Where(u => u.CedulaIdentidad == id)
                          .FirstOrDefault();
            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);
            return usuarioViewModel;
        }

        public UsuarioViewModel GetEntityByEmail(string email)
        {
            var usuario = _fortoulContext.Usuario
                          .Include(p => p.Perfil)
                          .Where(u => u.Correo == email)
                          .FirstOrDefault();
            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);
            return usuarioViewModel;
        }

        public bool Save()
        {
            return _fortoulContext.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateEntity(UsuarioViewModel entity)
        {
            _fortoulContext.Update(_mapper.Map<Usuario>(entity));
            return Save();
        }

        public UsuarioViewModel DoLogin(string mail, string password)
        {
            var usuario = _fortoulContext.Usuario
                          .Include(p => p.Perfil)
                          .Where(u => u.Correo == mail && u.Clave == password)
                          .FirstOrDefault();
            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);
            return usuarioViewModel;
        }
    }
}
