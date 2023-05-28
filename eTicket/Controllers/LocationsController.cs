using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class LocationsController : Controller
    {
        private readonly ILocationsService _service;

        public LocationsController(ILocationsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Locations/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Location location)
        {
            if (!ModelState.IsValid)
            {
                return View(location);
            }
            await _service.AddAsync(location);
            return RedirectToAction(nameof(Index));
        }

        //Get: Locations/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);

            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        //Get: Locations/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,  Location location)
        {
            if (!ModelState.IsValid)
            {
                return View(location);
            }

            if (id == location.Id)
            {
                await _service.UpdateAsync(id, location);
                return RedirectToAction(nameof(Index));
            }
            return View(location);

        }

        //Get: Locations/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");
            return View(locationDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locationDetails = await _service.GetByIdAsync(id);
            if (locationDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}