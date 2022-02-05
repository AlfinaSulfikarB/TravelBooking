using System;
using System.Collections.Generic;

namespace TravelBooking.Models
{
    public partial class TicketAmnt
    {
        public TicketAmnt()
        {
            TotalTicktCharge = new HashSet<TotalTicktCharge>();
        }

        public int TicketAmntId { get; set; }
        public int FlightId { get; set; }
        public int TaxAmnt { get; set; }
        public int HandlingChrg { get; set; }
        public int? BaggageChrg { get; set; }

        public virtual FlightData Flight { get; set; }
        public virtual ICollection<TotalTicktCharge> TotalTicktCharge { get; set; }
    }
}
