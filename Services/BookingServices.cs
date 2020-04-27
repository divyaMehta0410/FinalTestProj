using DataAccessLayer.Repository;
using SharedProject.Models;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Services
{
    public class BookingServices
    {
        private readonly BookingsRepository bookingsRepository;
        public BookingServices()
        {
            bookingsRepository = new BookingsRepository();
        }
        public bool AddBooking(Bookings booking) {
            var result = bookingsRepository.Add(booking);
                return result > 0;
        }
        public IEnumerable<Bookings> GetBokingsBetween(DateTime from,DateTime to) {
            return bookingsRepository.GetBookingsBetween(from, to);

        }
        public Bookings GetBooking(Guid referenceNumber) {
            return bookingsRepository.GetBooking(referenceNumber);
        }
        public bool DeleteBooking(Guid referenceNumber)
        {
            var result = bookingsRepository.Delete(referenceNumber);
            return result > 0;
        }


    }
}