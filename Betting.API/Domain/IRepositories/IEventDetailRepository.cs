using Betting.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.IRepositories
{
    public interface IEventDetailRepository
    {
        IEnumerable<EventDetail> List();
        Task Add(EventDetail eventDetail);
        Task<EventDetail> FindByIdAsync(long id);
        void Update(EventDetail eventDetail);
        void Delete(EventDetail eventDetail);
    }
}
