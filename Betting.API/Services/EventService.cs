using Betting.API.Domain.IRepositories;
using Betting.API.Domain.IServices;
using Betting.API.Domain.IServices.Communication;
using Betting.API.Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly ITournamentRepository _tournamentRepository;
        private readonly IUnitOfWork _unitOfWork;
      //  private readonly ILogger _logger;

        public EventService(IEventRepository eventRepository, ITournamentRepository tournamentRepository, IUnitOfWork unitOfWork)
        {
            _eventRepository = eventRepository;
            _tournamentRepository = tournamentRepository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Event> List()
        {
            return _eventRepository.List();
        }

        public async Task<EventResponse> AddAsync(Event eventToAdd)
        {
            var existingTournament = _tournamentRepository.FindByIdAsync(eventToAdd.TournamentId);

            try
            {
                if (existingTournament == null)
                    return new EventResponse("Invalid Tournament");

                await _eventRepository.Add(eventToAdd);
                await _unitOfWork.CompleteAsync();

                return new EventResponse(eventToAdd);
            }
            catch (Exception ex)
            {
                return new EventResponse($"An error occured when saving the event: {ex.Message}");
            }
        }

        public async Task<EventResponse> Update(int id, Event eventToUpdate)
        {
            var existingEvent = await _eventRepository.FindByIdAsync(id);

            if (existingEvent == null)
                return new EventResponse("Event not found");

            var existingTournament = await _tournamentRepository.FindByIdAsync(eventToUpdate.TournamentId);
            if (existingTournament == null)
                return new EventResponse("Invalid Tournament");

            existingEvent.Name = eventToUpdate.Name;
            existingEvent.EventNumber = eventToUpdate.EventNumber;
            existingEvent.EventDate = eventToUpdate.EventDate;
            existingEvent.EventEndDate = eventToUpdate.EventEndDate;
            existingEvent.AutoClose = eventToUpdate.AutoClose;
            existingEvent.TournamentId = eventToUpdate.TournamentId;

            try
            {
                _eventRepository.Update(existingEvent);
                await _unitOfWork.CompleteAsync();

                return new EventResponse(existingEvent);
            }
            catch (Exception ex)
            {
                return new EventResponse($"An error occured when updating the event: {ex.Message}");
            }

        }

        public async Task<EventResponse> Delete(int id)
        {
            var existingEvent = await _eventRepository.FindByIdAsync(id);

            if (existingEvent == null)
                return new EventResponse("Event not found");

            try
            {
                _eventRepository.Delete(existingEvent);
                await _unitOfWork.CompleteAsync();

                return new EventResponse(existingEvent);
            }
            catch (Exception ex)
            {
  
                return new EventResponse($"An error occured when deleting the event: {ex.Message}");
            }
        }
    }
}
