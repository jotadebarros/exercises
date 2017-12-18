using iMusicaCorp.Application.AppServices;
using iMusicaCorp.Application.Interfaces;
using iMusicaCorp.Domain.Interfaces.ReadOnly;
using iMusicaCorp.Domain.Interfaces.Repositories;
using iMusicaCorp.Domain.Interfaces.Services;
using iMusicaCorp.Domain.Services;
using iMusicaCorp.Infra.Data.Context;
using iMusicaCorp.Infra.Data.Interface;
using iMusicaCorp.Infra.Data.Repositories;
using iMusicaCorp.Infra.Data.Repositories.ReadOnly;
using iMusicaCorp.Infra.Data.Repositories.Repository;
using iMusicaCorp.Infra.Data.UoW;
using Ninject.Modules;

namespace iMusicaCorp.Infra.CrossCutting.IoC
{
    public class MusicaModulo : NinjectModule
    {
        public override void Load()
        {
            // App
            Bind<IEmployeeAppService>().To<EmployeeAppService>();
            Bind<IRoleAppService>().To<RoleAppService>();

            // Domain
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IRoleService>().To<RoleService>();

            // Data
            Bind<IContextManager>().To<ContextManager>();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IEmployeeRepository>().To<EmployeeRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();

            Bind<IEmployeeReadOnlyRepository>().To<EmployeeReadOnlyRepository>();
            Bind<IDependentReadOnlyRepository>().To<DependentReadOnlyRepositoryRepository>();

           
        }
    }
}
