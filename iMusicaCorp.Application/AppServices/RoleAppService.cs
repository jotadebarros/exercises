using AutoMapper;
using iMusicaCorp.Application.Interfaces;
using iMusicaCorp.Application.ViewModels;
using iMusicaCorp.Domain.Entities;
using iMusicaCorp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace iMusicaCorp.Application.AppServices
{
    public class RoleAppService : AppService, IRoleAppService
    {
        private readonly IRoleService _roleService;

        public RoleAppService(IRoleService roleService)
        {
            _roleService = roleService;
        }

        private static RoleViewModel RoleToViewModel(Role role)
        {
            return Mapper.Map<Role, RoleViewModel>(role);
        }

        private static Role ViewModelToRole(RoleViewModel roleViewModel)
        {
            return Mapper.Map<RoleViewModel, Role>(roleViewModel);
        }

        public RoleViewModel Add(RoleViewModel obj)
        {
            throw new System.NotImplementedException();
        }

        public RoleViewModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<RoleViewModel> GetAll()
        {
            var dados = _roleService.GetAll();

            return Mapper.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(dados);

       }

        public void Update(RoleViewModel obj)
        {
            throw new System.NotImplementedException();
        }
        public void Remove(RoleViewModel obj)
        {
            throw new System.NotImplementedException();
        }
        public void Dispose()
        {
            _roleService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
