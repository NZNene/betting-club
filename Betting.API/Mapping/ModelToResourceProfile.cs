using AutoMapper;
using Betting.API.Domain.Models;
using Betting.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Tournament, TournamentResource>();

            CreateMap<Event, EventResource>();
        }
    }
}
