using System;
using System.Collections.Generic;

namespace TravelBooking.Models
{
    public partial class FlightRoute
    {
        public FlightRoute()
        {
            FlightData = new HashSet<FlightData>();
        }

        public int FlightRouteId { get; set; }
        public int TravelerId { get; set; }
        public string DepartLocation { get; set; }
        public string DestinLocation { get; set; }

        public virtual Traveler Traveler { get; set; }
        public virtual ICollection<FlightData> FlightData { get; set; }
    }
}
