using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Betting.API.Domain.IServices;
using Betting.API.Domain.Models;
using Betting.API.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Betting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<EventResource> GetAllEventsAsync()
        {
            var events = _eventService.List();

            var resource = _mapper.Map<IEnumerable<Event>, IEnumerable<EventResource>>(events);
            return resource;
        }

        [HttpPost]
        [ProducesResponseType(typeof(EventResource), 201)]
        [ProducesResponseType(typeof(EventResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] EventResource resource)
        {
            var eventToSave = _mapper.Map<EventResource, Event>(resource);

            var result = await _eventService.AddAsync(eventToSave);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EventResource), 201)]
        [ProducesResponseType(typeof(EventResource), 400)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] EventResource resource)
        {
            var eventToUpdate = _mapper.Map<EventResource, Event>(resource);

            var result = await _eventService.Update(id, eventToUpdate);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EventResource), 201)]
        [ProducesResponseType(typeof(EventResource), 400)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _eventService.Delete(id);

            if (!result.Success)
                return BadRequest(new ErrorResource(result.Message));

            var eventResource = _mapper.Map<Event, EventResource>(result.Resource);
            return Ok(eventResource);

        }
    }
}
