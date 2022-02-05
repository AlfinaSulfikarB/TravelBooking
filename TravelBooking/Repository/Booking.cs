using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelBooking.Models;
using TravelBooking.ViewModel;

namespace TravelBooking.Repository
{
    public class Booking : IBooking
    {
        //datafields 

        private readonly travel_bookingContext _context;

        //default constructor
        public Booking(travel_bookingContext context)
        {
            _context = context;
        }

        #region Get all bookings(View Model)
        
        public async Task<List<BookingViewModel>> GetAllBookings()
        {
            if(_context!=null)
            {
                return await (from a in _context.Traveler
                              from b in _context.Passenger
                              from c in _context.FlightRoute
                              join d in _context.FlightData on c.FlightRouteId equals d.FlightRouteId
                              where a.TravelerId == b.TravelerId
                              select new BookingViewModel
                              {
                                  TravelerId = a.TravelerId,
                                  TravelerName = a.TravelerName,
                                  PassengerListId = b.PassengerListId,
                                  CoTravellrTotal = b.CoTravellrTotal,
                                  AdultTotal = b.AdultTotal,
                                  ChildTotal = b.ChildTotal,
                                  FlightRouteId = c.FlightRouteId,
                                  DepartLocation = c.DepartLocation,
                                  DestinLocation = c.DestinLocation,
                                  FlightId = d.FlightId,
                                  AirlineName = d.AirlineName,
                                  DepartTime = d.DepartTime,
                                  ArrivalTime = d.ArrivalTime,
                                  AdultCharge = d.AdultCharge,
                                  ChildCharge = d.ChildCharge,

                              }).ToListAsync();
            }
            return null;
        }


        #endregion

        #region Add traveler
        public async Task<int> AddTraveler(Traveler traveler)
        {
            if (_context != null)
            {
                await _context.Traveler.AddAsync(traveler);
                await _context.SaveChangesAsync();
                return traveler.TravelerId;
            }
            return 0;
        }


        #endregion

        #region Update Traveler
        public async Task UpdateTraveler(Traveler traveler)
        {
            if (_context != null)
            {
                _context.Entry(traveler).State = EntityState.Modified;
                _context.Traveler.Update(traveler);
                await _context.SaveChangesAsync();
            }

        }
        #endregion

        #region Delete Traveler
        public async Task<int> DeleteTraveler(int? id)
        {
            int result = 0;
            if (_context != null)
            {
                var traveler = await _context.Traveler.FirstOrDefaultAsync(trvl => trvl.TravelerId == id);

                //check
                if (traveler != null)
                {
                    _context.Traveler.Remove(traveler);

                    //commit 
                    result = await _context.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        #endregion

        
        #region Get booking with date
         public async Task<List<BookingViewModel>> GetBookingsByDate()
         {
             if(_context !=null)
             {
                 return await (from a in _context.FlightData
                               from b in _context.FlightRoute
                               from c in _context.Passenger
                               join d in _context.Traveler on c.TravelerId equals d.TravelerId
                               where a.DepartTime==(DateTime.Today).AddDays(-1) &&  b.DepartLocation=="Trivandrum Int Airport"
                               select new BookingViewModel
                               {
                                   TravelerId = d.TravelerId,
                                   TravelerName = d.TravelerName,
                                   PassengerListId = c.PassengerListId,
                                   CoTravellrTotal = c.CoTravellrTotal,
                                   AdultTotal = c.AdultTotal,
                                   ChildTotal = c.ChildTotal,
                                   FlightRouteId = b.FlightRouteId,
                                   DepartLocation = b.DepartLocation,
                                   DestinLocation = b.DestinLocation,
                                   FlightId = a.FlightId,
                                   AirlineName = a.AirlineName,
                                   DepartTime = a.DepartTime,
                                   ArrivalTime = a.ArrivalTime,
                                    AdultCharge = a.AdultCharge,
                                   ChildCharge = a.ChildCharge,

                               }).ToListAsync();
             }
             return null;
         }
        #endregion

        #region Get booking from Airport "IndiraGandhi Airport, Delhi"
        public async Task<List<BookingViewModel>> GetBookingsByAirport()
        {
            if (_context != null)
            {
                return await (from a in _context.FlightData
                              from b in _context.FlightRoute
                              from c in _context.Passenger
                              join d in _context.Traveler on c.TravelerId equals d.TravelerId
                              where b.DepartLocation == "IndiraGandhi Airport, Delhi"
                              select new BookingViewModel
                              {
                                  TravelerId = d.TravelerId,
                                  TravelerName = d.TravelerName,
                                  PassengerListId = c.PassengerListId,
                                  CoTravellrTotal = c.CoTravellrTotal,
                                  AdultTotal = c.AdultTotal,
                                  ChildTotal = c.ChildTotal,
                                  FlightRouteId = b.FlightRouteId,
                                  DepartLocation = b.DepartLocation,
                                  DestinLocation = b.DestinLocation,
                                  FlightId = a.FlightId,
                                  AirlineName = a.AirlineName,
                                  DepartTime = a.DepartTime,
                                  ArrivalTime = a.ArrivalTime,
                                  AdultCharge = a.AdultCharge,
                                  ChildCharge = a.ChildCharge,

                              }).ToListAsync();
            }
            return null;
        }
        #endregion




    }
}
