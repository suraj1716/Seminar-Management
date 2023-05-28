using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class EventsController : Controller
    {
        private readonly IEventsService _service;
        private readonly AppDbContext context;

        public EventsController(IEventsService service)
        {
            _service = service;
        }


     
       

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allEvents = await _service.GetAllAsync(n => n.Location);
            return View(allEvents);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allEvents = await _service.GetAllAsync(n => n.Location);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allEvents.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allEvents.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allEvents);
        }

        //GET: Events/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var eeventDetail = await _service.GetEventByIdAsync(id);


            var username = "suraj";
            //var i=context.Bookings.Where(ut => ut.User.UserName == username).Select(ut => ut.BookingItems.Select(ure => ure.Event)).ToList();
           
            return View(eeventDetail);
        }

        //GET: Events/Create
        public async Task<IActionResult> Create()
        {
          

            var eeventDropdownsData = await _service.GetNewEventDropdownsValues();

            ViewBag.Locations = new SelectList(eeventDropdownsData.Locations, "Id", "Address");
            ViewBag.Coordinators = new SelectList(eeventDropdownsData.Coordinators, "Id", "FullName");
            ViewBag.Speakers = new SelectList(eeventDropdownsData.Speakers, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewEventVM eevent)
        { 
            if (!ModelState.IsValid)
            {
                var eeventDropdownsData = await _service.GetNewEventDropdownsValues();

                ViewBag.Locations = new SelectList(eeventDropdownsData.Locations, "Id", "Address");
                ViewBag.Coordinators = new SelectList(eeventDropdownsData.Coordinators, "Id", "FullName");
                ViewBag.Speakers = new SelectList(eeventDropdownsData.Speakers, "Id", "FullName");

                return View(eevent);
            }

            await _service.AddNewEventAsync(eevent);
            return RedirectToAction(nameof(Index));
        }


        //GET: Events/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var eeventDetails = await _service.GetEventByIdAsync(id);
            if (eeventDetails == null) return View("NotFound");

            var response = new NewEventVM()
            {
                Id = eeventDetails.Id,
                Name = eeventDetails.Name,
                Description = eeventDetails.Description,
                Price = eeventDetails.Price,
                StartDate = eeventDetails.StartDate,
                Time = eeventDetails.Time,
                ImageURL = eeventDetails.ImageURL,
                EventCategory = eeventDetails.EventCategory,
                LocationId = eeventDetails.LocationId,
                CoordinatorId = eeventDetails.CoordinatorId,
                SpeakerIds = eeventDetails.Speakers_Events.Select(n => n.SpeakerId).ToList(),
            };

            var eeventDropdownsData = await _service.GetNewEventDropdownsValues();
            ViewBag.Locations = new SelectList(eeventDropdownsData.Locations, "Id", "Address");
            ViewBag.Coordinators = new SelectList(eeventDropdownsData.Coordinators, "Id", "FullName");
            ViewBag.Speakers = new SelectList(eeventDropdownsData.Speakers, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewEventVM eevent)
        {
            if (id != eevent.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var eeventDropdownsData = await _service.GetNewEventDropdownsValues();

                ViewBag.Locations = new SelectList(eeventDropdownsData.Locations, "Id", "Address");
                ViewBag.Coordinators = new SelectList(eeventDropdownsData.Coordinators, "Id", "FullName");
                ViewBag.Speakers = new SelectList(eeventDropdownsData.Speakers, "Id", "FullName");

                return View(eevent);
            }

            await _service.UpdateEventAsync(eevent);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var eventDetails = await _service.GetEventByIdAsync(id);
            if (eventDetails == null) return View("NotFound");
            return View(eventDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventDetails = await _service.GetEventByIdAsync(id);
            if (eventDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}