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
            this.CreateMap<SelectivityCalculation, CreateSelectivityCalculationCommand>()
                .ForCtorParam("calculationID", opts => opts.MapFrom((_, ctx) => ctx.Items["calculationID"]))
                .ForCtorParam("actionDateTime", opts => opts.MapFrom((_, ctx) => ctx.Items["actionDateTime"]))
                .ForCtorParam("actionUserID", opts => opts.MapFrom((_, ctx) => ctx.Items["actionUserID"]));
        }
    }
}
