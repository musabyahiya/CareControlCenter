using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CareControl_Web.Controllers
{
    public class ClientAreaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddServiceUser()
        {
            return View();
        }
        public IActionResult RecordDeath()
        {
            return View();
        }

        public IActionResult ResidentLeaving()
        {
            return View();
        }

        public IActionResult ReactivateResident()
        {
            return View();
        }

        public IActionResult RecordPlannedAbsence()
        {
            return View();
        }
    }
}
