using iMusicaCorp.Domain.Entities;
using iMusicaCorp.Domain.Interfaces.Repositories;
using iMusicaCorp.Domain.Interfaces.Services;

namespace iMusicaCorp.Domain.Services
{
    public class RoleService:ServiceBase<Role>,IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository):base(roleRepository)
        {
            _roleRepository = roleRepository;
        }
    }
}
