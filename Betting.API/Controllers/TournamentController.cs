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
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentService _tournamentService;
        private readonly IMapper _mapper;

        public TournamentController(ITournamentService tournamentService, IMapper mapper)
        {
            _tournamentService = tournamentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<Tournament>> GetAllAsync()
        {
            var tournaments = await _tournamentService.ListAsync();
            return tournaments;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TournamentResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> PostAsync([FromBody] TournamentResource resource)
        {
            var tournament = _mapper.Map<TournamentResource, Tournament>(resource);
            var result = await _tournamentService.SaveAsync(tournament);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);
            return Ok(tournamentResource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TournamentResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> PutAsync(int id, [FromBody] TournamentResource resource)
        {
            var tournament = _mapper.Map<TournamentResource, Tournament>(resource);
            var result = await _tournamentService.UpdateAsync(id, tournament);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);
            return Ok(tournamentResource);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TournamentResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 4001)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _tournamentService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var tournamentResource = _mapper.Map<Tournament, TournamentResource>(result.Resource);
            return Ok(tournamentResource);
        }
    }
}
