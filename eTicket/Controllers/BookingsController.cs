using eTickets.Data.Cart;
using eTickets.Data.Services;
//using eTickets.Data.Static;
using eTickets.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
   
    public class BookingsController : Controller
    {
        private readonly IEventsService _eventsService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IBookingsService _bookingsService;

        public BookingsController(IEventsService eventsService, ShoppingCart shoppingCart, IBookingsService bookingsService)
        {
            _eventsService = eventsService;
            _shoppingCart = shoppingCart;
            _bookingsService = bookingsService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
     
            var bookings = await _bookingsService.GetBookingsByUserIdAndRoleAsync(userId,userRole);
            return View(bookings);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {

            if (User.Identity.IsAuthenticated)
            {

                var item = await _eventsService.GetEventByIdAsync(id);

                if (item != null)
                {
                    _shoppingCart.AddItemToCart(item);
                }
                return RedirectToAction(nameof(ShoppingCart));

            }

            else {
                return RedirectToAction("Login","Account");
            }
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _eventsService.GetEventByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteBooking()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
            
             
                DateTime date = DateTime.Now;
                string _dateOnlyString = date.ToShortDateString();
            

            await _bookingsService.StoreBookingAsync(items, userId, userEmailAddress, _dateOnlyString);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("BookingCompleted");

        }
    }
}