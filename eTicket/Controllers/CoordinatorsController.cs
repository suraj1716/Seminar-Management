
using eTickets.Data;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CoordinatorsController : Controller
    {
        private readonly ICoordinatorsService _service;

        public CoordinatorsController(ICoordinatorsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCoordinators = await _service.GetAllAsync();
            return View(allCoordinators);
        }

        //GET: coordinators/details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var coordinatorDetails = await _service.GetByIdAsync(id);
            if (coordinatorDetails == null) return View("NotFound");
            return View(coordinatorDetails);
        }

        //GET: coordinators/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL,FullName,Bio")] Coordinator coordinator)
        {
            if (!ModelState.IsValid) return View(coordinator);

            await _service.AddAsync(coordinator);
            return RedirectToAction(nameof(Index));
        }

        //GET: coordinators/edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var coordinatorDetails = await _service.GetByIdAsync(id);
            if (coordinatorDetails == null) return View("NotFound");
            return View(coordinatorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProfilePictureURL,FullName,Bio")] Coordinator coordinator)
        {
            if (!ModelState.IsValid) return View(coordinator);

            if (id == coordinator.Id)
            {
                await _service.UpdateAsync(id, coordinator);
                return RedirectToAction(nameof(Index));
            }
            return View(coordinator);
        }

        //GET: coordinators/delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var coordinatorDetails = await _service.GetByIdAsync(id);
            if (coordinatorDetails == null) return View("NotFound");
            return View(coordinatorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coordinatorDetails = await _service.GetByIdAsync(id);
            if (coordinatorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}