namespace DomainModel.Infrastructure
{
    using ApiGateway.Documents.Commands;
    using ApiGateway.Models.DomainModels;
    using AutoMapper;

    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.Register();
        }

        public void Register()
        {
            this.CreateMap<Calculation, CreateSelectivityAndActivityCalculationCommand>()
                .ForCtorParam("actionDateTime", opts => opts.MapFrom((_, ctx) => ctx.Items["Datetime"]));
        }
    }
}
