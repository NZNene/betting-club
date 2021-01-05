using Betting.API.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.IServices.Communication
{
    public class EventDetailResponse : BaseResponse<EventDetail>
    {
        public EventDetailResponse(EventDetail resource) : base(resource)
        {
        }

        public EventDetailResponse(string message) : base(message)
        {
        }
    }
}
