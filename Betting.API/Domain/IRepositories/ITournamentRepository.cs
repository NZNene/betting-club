using Betting.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.IRepositories
{
    public interface ITournamentRepository
    {
        IEnumerable<Tournament> ListAsync();
        Task AddAsync(Tournament tournament);
        Task<Tournament> FindByIdAsync(long id);
        void Update(Tournament tournament);
        void Delete(Tournament tournament);
    }
}
