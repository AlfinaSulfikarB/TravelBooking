using System;
using System.Collections.Generic;

namespace TravelBooking.Models
{
    public partial class TotalTicktCharge
    {
        public int ChargeId { get; set; }
        public int PassengerListId { get; set; }
        public int TicketAmountId { get; set; }
        public int FlightId { get; set; }
        public int TotalAmnt { get; set; }

        public virtual FlightData Flight { get; set; }
        public virtual Passenger PassengerList { get; set; }
        public virtual TicketAmnt TicketAmount { get; set; }
    }
}
