using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChartJSSelectTest.Controllers
{
    public class ChartSelectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
