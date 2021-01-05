using Betting.API.Domain.IServices.Communication;
using Betting.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.IServices
{
    public interface IEventDetailService
    {
        IEnumerable<EventDetail> List();
        Task<EventDetailResponse> AddAsync(EventDetail eventToAdd);
        Task<EventDetailResponse> Update(int id, EventDetail eventToUpdate);
        Task<EventDetailResponse> Delete(int id);
    }
}
