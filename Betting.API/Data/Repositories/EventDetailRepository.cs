using Betting.API.Data.Context;
using Betting.API.Domain.IRepositories;
using Betting.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Data.Repositories
{
    public class EventDetailRepository : BaseRepository, IEventDetailRepository
    {
        public EventDetailRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<EventDetail> List()
        {
            return _context.EventDetails.Include(e => e.Event)
                .Include(x => x.EventDetailStatus).AsNoTracking();
        }

        public async Task Add(EventDetail eventDetail)
        {
            await _context.EventDetails.AddAsync(eventDetail);
        }

        public async Task<EventDetail> FindByIdAsync(long id)
        {
            return await _context.EventDetails.Include(e => e.Event)
                        .Include(x => x.EventDetailStatus)
                        .FirstOrDefaultAsync(x => x.EventDetailId == id);
        }

        public void Update(EventDetail eventDetail)
        {
            _context.EventDetails.Update(eventDetail);
        }

        public void Delete(EventDetail eventDetail)
        {
            _context.EventDetails.Remove(eventDetail);
        }
    }
}
