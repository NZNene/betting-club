using Betting.API.Domain.IServices.Communication;
using Betting.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.IServices
{
    public interface IEventService
    {
        IEnumerable<Event> List();
        Task<EventResponse> AddAsync(Event eventToAdd);
        Task<EventResponse> Update(int id, Event eventToUpdate);
        Task<EventResponse> Delete(int id);
    }
}
