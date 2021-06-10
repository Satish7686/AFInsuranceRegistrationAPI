using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFInsuranceRegistrationAPI.Controllers
{
    public class InsuranceRegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
