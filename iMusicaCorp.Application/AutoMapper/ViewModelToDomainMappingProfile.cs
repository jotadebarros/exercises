using AutoMapper;
using iMusicaCorp.Application.ViewModels;
using iMusicaCorp.Domain.Entities;

namespace iMusicaCorp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EmployeeViewModel, Employee>();
            Mapper.CreateMap<RoleViewModel, Role>();
            Mapper.CreateMap<DependentViewModel, Dependent>();
        }
    }
}

