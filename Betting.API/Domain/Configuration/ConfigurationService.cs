using Betting.API.Data.Repositories;
using Betting.API.Domain.IRepositories;
using Betting.API.Domain.IServices;
using Betting.API.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.Configuration
{
    public static class ConfigurationService
    {
        public static void ServiceCollection(this IServiceCollection services)
        {
            services.AddScoped<ITournamentRepository, TournamentRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ITournamentService, TournamentService>();
            services.AddScoped<IEventService, EventService>();
        }
    }
}
