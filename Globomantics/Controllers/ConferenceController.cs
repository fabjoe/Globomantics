using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Controllers
{
    public class ConferenceController : Controller
    {
        private readonly IConferenceService _service;
        public ConferenceController(IConferenceService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index ()
        {
            ViewBag.Title = "Conference Overview";
            return View(await _service.GetAll());
        }
        public IActionResult Add()
        {
            ViewBag.Title = "Add Conference";
            return View(new ConferenceModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
                await _service.Add(model);
            return RedirectToAction("Index");
        }

    }
}
