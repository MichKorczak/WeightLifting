using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WeightLifting.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
