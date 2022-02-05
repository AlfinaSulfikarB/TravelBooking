using System;
using System.Collections.Generic;

namespace TravelBooking.Models
{
    public partial class FlightData
    {
        public FlightData()
        {
            Passenger = new HashSet<Passenger>();
            TicketAmnt = new HashSet<TicketAmnt>();
            TotalTicktCharge = new HashSet<TotalTicktCharge>();
        }

        public int FlightId { get; set; }
        public int FlightRouteId { get; set; }
        public string AirlineName { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AdultCharge { get; set; }
        public int ChildCharge { get; set; }

        public virtual FlightRoute FlightRoute { get; set; }
        public virtual ICollection<Passenger> Passenger { get; set; }
        public virtual ICollection<TicketAmnt> TicketAmnt { get; set; }
        public virtual ICollection<TotalTicktCharge> TotalTicktCharge { get; set; }
    }
}
