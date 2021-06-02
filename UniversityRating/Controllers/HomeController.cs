using BLL;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UniversityRating.Models;

namespace UniversityRating.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IIndicatorLogic indicatorLogic;

        public HomeController(ILogger<HomeController> logger, IIndicatorLogic indicatorLogic)
        {
            _logger = logger;
            this.indicatorLogic = indicatorLogic;
        }

        public IActionResult Index(int universityId = 1)
        {
            var indicators = indicatorLogic.GetAllIndicators(universityId);
            List<IndicatorVM> indicatorsVM = indicators.Select(o =>
            new IndicatorVM
            {
                IndicatorId = o.IndicatorId,
                UniversityId = o.UniversityId,
                IndicatorName = o.IndicatorName,
                Value = o.Value,
                UnitOfMeasure = o.UnitOfMeasure,
                UniversityName = o.UniversityName
            }).ToList();
            return View(indicatorsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateIndicator(List<IndicatorVM> indicators)
        {
            var x = 1;
            Console.WriteLine("jasdkadmklad");
            return null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
