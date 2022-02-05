using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TravelBooking.Models;
using System.Threading.Tasks;
using TravelBooking.ViewModel;

namespace TravelBooking.Repository
{
    public interface IBooking
    {
        //get all bookings

        Task<List<BookingViewModel>> GetAllBookings();


        //add new traveler

        Task<int> AddTraveler(Traveler traveler);

        //update traveler

        Task UpdateTraveler(Traveler traveler);

        //delete traveler
        Task<int> DeleteTraveler(int? id);


        //get bookings by departure date
        Task<List<BookingViewModel>> GetBookingsByDate();


        //get bookings by airport
        Task<List<BookingViewModel>> GetBookingsByAirport();
        


    }
}
