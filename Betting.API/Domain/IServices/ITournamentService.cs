using Betting.API.Domain.IServices.Communication;
using Betting.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.IServices
{
    public interface ITournamentService
    {
        Task<IEnumerable<Tournament>> ListAsync();
        Task<TournamentResponse> SaveAsync(Tournament tournament);
        Task<TournamentResponse> UpdateAsync(int id, Tournament tournament);
        Task<TournamentResponse> DeleteAsync(int id);
    }
}
