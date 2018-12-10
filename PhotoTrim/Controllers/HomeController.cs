using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoTrim.Models;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.IO;

namespace PhotoTrim.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        [HttpPost]
        public FileStreamResult Index(IList<IFormFile> files)
        {
            using (Image img = Image.FromStream(files[0].OpenReadStream()))
            {
                Stream ms = new MemoryStream(img.Resize(200, 200).ToByteArray());

                return new FileStreamResult(ms, "image/jpg");
            }
        }
    }
}
