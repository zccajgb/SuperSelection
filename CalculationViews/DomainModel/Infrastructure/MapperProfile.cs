namespace DomainModel.Infrastructure
{
    using AutoMapper;
    using DomainModel.Entities;
    using DomainModel.ViewModels;
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.Register();
        }

        public void Register()
        {
            this.CreateMap<SelectivityCalculationsEntity, SelectivityCalculationViewModel>();
        }
    }
}
