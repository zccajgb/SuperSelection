using ApiGateway.Documents.Commands;
using ApiGateway.Models.DomainModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            Register();
        }

        public void Register()
        {
            this.CreateMap<Calculation, CreateSelectivityAndActivityCalculationCommand>()
                .ForCtorParam("actionDateTime", opts => opts.MapFrom((_, ctx) => ctx.Items["Datetime"]));
        }
    }
}
