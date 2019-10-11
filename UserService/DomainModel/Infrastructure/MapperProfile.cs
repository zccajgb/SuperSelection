using AutoMapper;
using DomainModel.Models;
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
            this.CreateMap<User, UserView>()
                .ForCtorParam("token", opts => opts.MapFrom((_, ctx) => ctx.Items["Token"]));
        }
    }
}
