using System.Collections.Generic;
using ChartJSSelectTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChartJSSelectTest.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SaveData([FromBody] List<SelectedDataModel> models)
        {
            var date = models?[0].x.ToLocalTime();
            return Json($"First date: {date}");
        }
    }
}
