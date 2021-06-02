using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityRating.Models;

namespace UniversityRating.Controllers
{
    public class IndicatorController : Controller
    {

        private readonly IIndicatorLogic indicatorLogic;

        public IndicatorController(IIndicatorLogic indicatorLogic)
        {
            this.indicatorLogic = indicatorLogic;
        }

        // GET: IndicatorController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Indicators(int universityId)
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

        // GET: IndicatorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndicatorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndicatorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndicatorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndicatorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IndicatorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndicatorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
