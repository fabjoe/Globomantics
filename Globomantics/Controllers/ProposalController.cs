using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Controllers
{
    public class ProposalController : Controller
    {
        private readonly IConferenceService _conferenceService;
        private readonly IProposalService _proposalService;
        public ProposalController(IConferenceService conferenceService, IProposalService proposalService)
        {
            _conferenceService = conferenceService;
            _proposalService = proposalService;
        }

        public async Task<IActionResult> Index (int conferenceId)
        {
            var conference = await _conferenceService.GetById(conferenceId);
            ViewBag.Title = $"Proposal For Conference {conference.Name} {conference.Location}";
            ViewBag.ConferenceId = conferenceId;

            return View(await _proposalService.GetAll(conferenceId));
        }

        public IActionResult Add(int conferenceId)
        {
            ViewBag.Title = "Add Proposal";
            return View(new ProposalModel { ConferenceId = conferenceId });
        }
        [HttpPost]
        public async Task<IActionResult> Add(ProposalModel model)
        {
            if (ModelState.IsValid)
                await _proposalService.Add(model);
            return RedirectToAction("Index", new { conferenceId = model.ConferenceId});
        }
        public async Task<IActionResult> Approve(int proposalId)
        {
            var proposal = await _proposalService.Approve(proposalId);
            return RedirectToAction("Index", new { conferenceId = proposal.ConferenceId });
        }
    }
}
