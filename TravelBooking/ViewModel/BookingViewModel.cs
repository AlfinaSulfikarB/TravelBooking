using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TravelBooking.ViewModel
{
    public class BookingViewModel
    {
        //traveller model
        public int TravelerId { get; set; }
        public string TravelerName { get; set; }

        //passenger model

        public int PassengerListId { get; set; }
        public int CoTravellrTotal { get; set; }
        public int AdultTotal { get; set; }
        public int ChildTotal { get; set; }

        //flight data model

        public int FlightId { get; set; }

        public string AirlineName { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int AdultCharge { get; set; }
        public int ChildCharge { get; set; }

        //flight route model

        public int FlightRouteId { get; set; }

        public string DepartLocation { get; set; }
        public string DestinLocation { get; set; }


    }
}
