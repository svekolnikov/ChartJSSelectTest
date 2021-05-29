using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using ChartJSSelectTest.Models;
using ChartJSSelectTest.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public JsonResult SaveImg([FromBody] string img)
        {
            Bitmap chartBitmap = img.Base64StringToBitmap();

            // Assumes myImage is the PNG you are converting
            using (var b = new Bitmap(chartBitmap))
            {
                b.SetResolution(chartBitmap.HorizontalResolution, chartBitmap.VerticalResolution);

                using (var g = Graphics.FromImage(b))
                {
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(chartBitmap, 0, 0);
                }

                b.Save("chartBitmap.jpeg", ImageFormat.Jpeg);
            }

            chartBitmap.Save("chartBitmap.png", ImageFormat.Png);
            return Json("Image saved");
        }
    }
}
