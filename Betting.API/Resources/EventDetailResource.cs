using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Resources
{
    public class EventDetailResource
    {

        [Required]
        public string EventDetailName { get; set; }

        [Required]
        public int EventDetailNumber { get; set; }

        [Required]
        public decimal EventDetailOdd { get; set; }

        [Required]
        public string FinishingPosition { get; set; }
        public bool FirstTimer { get; set; }

        [Required]
        public long EventId { get; set; }
    }
}
