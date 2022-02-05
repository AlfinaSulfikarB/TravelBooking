using System;
using System.Collections.Generic;

namespace TravelBooking.Models
{
    public partial class Passenger
    {
        public Passenger()
        {
            TotalTicktCharge = new HashSet<TotalTicktCharge>();
        }

        public int PassengerListId { get; set; }
        public int TravelerId { get; set; }
        public int FlightId { get; set; }
        public int CoTravellrTotal { get; set; }
        public int AdultTotal { get; set; }
        public int ChildTotal { get; set; }

        public virtual FlightData Flight { get; set; }
        public virtual Traveler Traveler { get; set; }
        public virtual ICollection<TotalTicktCharge> TotalTicktCharge { get; set; }
    }
}
