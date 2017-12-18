using AutoMapper;
using iMusicaCorp.Application.ViewModels;
using iMusicaCorp.Domain.Entities;

namespace iMusicaCorp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Employee, EmployeeViewModel>();
            Mapper.CreateMap<Role, RoleViewModel>();
            Mapper.CreateMap<Dependent, DependentViewModel>();
        }
    }
}
