using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class BookingsService : IBookingsService
    {   
        private readonly AppDbContext _context;
        public BookingsService(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<Booking>> GetBookingsByUserIdAndRoleAsync(string userId, string userRole)
        {
            var bookings = await _context.Bookings.Include(n => n.BookingItems).ThenInclude(n => n.Event).Include(n=>n.User).ToListAsync();
            
            if (userRole != "Admin")
            {
                bookings = bookings.Where(n => n.UserId == userId).ToList();
            }

            return bookings;
        }

      


        //public async Task<List<Booking>> GetBookingByUserIdAsync(string userId)
        //{
        //    var bookings = await _context.Booking.Include(n => n.BookingItems).ThenInclude(n => n.Event).Where(n => n.UserId == userId).ToListAsync();

        //    return bookings;
        //}

        public async Task StoreBookingAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress, string date)
        {
            var booking = new Booking()
            {
                UserId = userId,
                Email = userEmailAddress,
                Date = date
            };
            await _context.Bookings.AddAsync(booking);
           
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {  
                var bookingItem = new BookingItem()
                {
                    Amount = item.Amount,
                    EventId = item.Event.Id,
                    BookingId = booking.Id,
                    Price = item.Event.Price
                };
                await _context.BookingItems.AddAsync(bookingItem);
            }
            await _context.SaveChangesAsync();
        }

        
    }
}