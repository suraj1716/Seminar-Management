using eTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public interface IBookingsService
    {
        Task StoreBookingAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress, string date);
        Task<List<Booking>> GetBookingsByUserIdAndRoleAsync(string userId, string userRole);

        
    }
}