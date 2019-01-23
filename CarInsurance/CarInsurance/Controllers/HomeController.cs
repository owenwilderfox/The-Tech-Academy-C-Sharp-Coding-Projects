using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsurance.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Quote(string FirstName, string LastName, string EmailAddress, string DateOfBirth, string CarYear, string CarMake,
            string CarModel, string Dui, string MovingViolations, string CoverageType)
        {

        }
    }
}