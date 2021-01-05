using Betting.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.IRepositories
{
    public interface IEventRepository
    {
        IEnumerable<Event> List();
        Task Add(Event eventToAdd);
        Task<Event> FindByIdAsync(long id);
        void Update(Event enventToUpdate);
        void Delete(Event eventToDelete);
    }
}

