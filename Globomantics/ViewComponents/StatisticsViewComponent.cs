using Globomantics.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.ViewComponents
{
    public class StatisticsViewComponent : ViewComponent
    {
        private readonly IConferenceService _conferenceService;
        public StatisticsViewComponent(IConferenceService conferenceService)
        {
            _conferenceService = conferenceService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _conferenceService.GetStatistics());
        }
    }
}
