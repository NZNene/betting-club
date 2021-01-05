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
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {
        }

        public IEnumerable<Event> List()
        {
            return _context.Events
                .Include(e => e.Tournament).AsNoTracking();
        }

        public async Task Add(Event eventToAdd)
        {
            await _context.Events.AddAsync(eventToAdd);
        }

        public async Task<Event> FindByIdAsync(long id)
        {
            return await _context.Events.FindAsync(id);
        }

        public void Update(Event enventToUpdate)
        {
            _context.Events.Update(enventToUpdate);
        }

        public void Delete(Event eventToDelete)
        {
            _context.Events.Remove(eventToDelete);
        }
    }
}

