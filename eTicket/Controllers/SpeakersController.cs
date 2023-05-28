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
    public class SpeakersController : Controller
    {
        private readonly ISpeakerService _service;

        public SpeakersController(ISpeakerService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Speakers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                return View(speaker);
            }
            await _service.AddAsync(speaker);
            return RedirectToAction(nameof(Index));
        }

        //Get: Speakers/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var speakerDetails = await _service.GetByIdAsync(id);

            if (speakerDetails == null) return View("NotFound");
            return View(speakerDetails);
        }

        //Get: Speakers/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var speakerDetails = await _service.GetByIdAsync(id);
            if (speakerDetails == null) return View("NotFound");
            return View(speakerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Speaker speaker)
        {
            if (!ModelState.IsValid)
            {
                return View(speaker);
            }

            if (id == speaker.Id)
            {
                await _service.UpdateAsync(id, speaker);
                return RedirectToAction(nameof(Index));
            }
            return View(speaker);

        }

        //Get: Speakers/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var speakerDetails = await _service.GetByIdAsync(id);
            if (speakerDetails == null) return View("NotFound");
            return View(speakerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var speakerDetails = await _service.GetByIdAsync(id);
            if (speakerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}