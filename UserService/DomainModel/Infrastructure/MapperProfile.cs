namespace DomainModel.Infrastructure
{
    using AutoMapper;
    using DomainModel.Models;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.Register();
        }

        public void Register()
        {
            this.CreateMap<User, UserView>()
                .ForCtorParam("token", opts => opts.MapFrom((_, ctx) => ctx.Items["Token"]));
        }
    }
}
