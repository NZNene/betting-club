using Betting.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.IServices.Communication
{
    public class TournamentResponse : BaseResponse<Tournament>
    {
        public TournamentResponse(Tournament resource) : base(resource)
        {
        }

        public TournamentResponse(string message) : base(message)
        {
        }
    }
}
