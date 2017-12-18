using System;
using System.Collections.Generic;
using iMusicaCorp.Application.ViewModels;

namespace iMusicaCorp.Application.Interfaces
{
   public interface IRoleAppService : IDisposable
    {
        RoleViewModel Add(RoleViewModel obj);
        RoleViewModel GetById(int id);
        IEnumerable<RoleViewModel> GetAll();
        void Update(RoleViewModel obj);
        void Remove(RoleViewModel obj);
    }
}
