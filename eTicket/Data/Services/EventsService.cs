using eTickets.Data.Base;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{  
    public class EventsService : EntityBaseRepository<Event>, IEventsService
    {
        private readonly AppDbContext _context;
        public EventsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewEventAsync(NewEventVM data)
        {
            var newEvent = new Event()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                LocationId = data.LocationId,
                StartDate = data.StartDate,
                Time = data.Time,
                EventCategory = data.EventCategory,
                CoordinatorId = data.CoordinatorId
            };
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            //Add Event Speakers
            foreach (var actorId in data.SpeakerIds)
            {
                var newSpeakerEvent = new Speaker_Event()
                {
                    EventId = newEvent.Id,
                    SpeakerId = actorId
                };
                await _context.Speakers_Events.AddAsync(newSpeakerEvent);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            var eventDetails = await _context.Events
                .Include(c => c.Location)
                .Include(p => p.Coordinator)
                .Include(am => am.Speakers_Events).ThenInclude(a => a.Speaker)
                .FirstOrDefaultAsync(n => n.Id == id);

            return eventDetails;
        }

        public async Task<NewEventDropdownsVM> GetNewEventDropdownsValues()
        {
            var response = new NewEventDropdownsVM()
            {

                Speakers = await _context.Speakers.OrderBy(n => n.FullName).ToListAsync(),
                Locations = await _context.Locations.OrderBy(n => n.Address).ToListAsync(),
                Coordinators = await _context.Coordinators.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateEventAsync(NewEventVM data)
        {
            var dbEvent = await _context.Events.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbEvent != null)
            {
                dbEvent.Name = data.Name;
                dbEvent.Description = data.Description;
                dbEvent.Price = data.Price;
                dbEvent.ImageURL = data.ImageURL;
                dbEvent.LocationId = data.LocationId;
                dbEvent.StartDate = data.StartDate;
                dbEvent.Time = data.Time;
                dbEvent.EventCategory = data.EventCategory;
                dbEvent.CoordinatorId = data.CoordinatorId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingSpeakersDb = _context.Speakers_Events.Where(n => n.EventId == data.Id).ToList();
            _context.Speakers_Events.RemoveRange(existingSpeakersDb);
            await _context.SaveChangesAsync();

            //Add Event Speakers
            foreach (var actorId in data.SpeakerIds)
            {
                var newSpeakerEvent = new Speaker_Event()
                {
                    EventId = data.Id,
                    SpeakerId = actorId
                };
                await _context.Speakers_Events.AddAsync(newSpeakerEvent);
            }
            await _context.SaveChangesAsync();
        }
    }
}