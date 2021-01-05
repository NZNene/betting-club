using Betting.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.IServices.Communication
{
    public class EventResponse : BaseResponse<Event>
    {
        public EventResponse(Event resource) : base(resource)
        {
        }

        public EventResponse(string message) : base(message)
        {
        }
    }
}
