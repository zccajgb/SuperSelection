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
        }

        public void Register()
        {
            this.CreateMap<User, UserView>()
                .ForMember(x => x.Token,opts => opts.MapFrom((s, d, dm, ctx) => ctx.Items["Token"]));
        }
    }
}
