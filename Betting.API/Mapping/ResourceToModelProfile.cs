using AutoMapper;
using Betting.API.Domain.Models;
using Betting.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<TournamentResource, Tournament>();

            CreateMap<EventResource, Event>();
        }
    }
}
