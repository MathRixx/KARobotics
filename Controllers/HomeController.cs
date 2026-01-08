using KAR_Robotics.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Text;

namespace KAR_Robotics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

            public IActionResult Index()
        {
            return View();
        }

        //    public IActionResult Privacy()
        //    {
        //        return View();
        //    }

        //    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //    public IActionResult Error()
        //    {
        //        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //    }

        //    public IActionResult TestLoc(
        //[FromServices] IStringLocalizer<SharedResource> sr)
        //    {
        //        // 1) Localizer ne döndürüyor?
        //        var value = sr["Test"].Value;

        //        // 2) Assembly içindeki tüm embedded resource isimlerini listele
        //        var asm = typeof(SharedResource).Assembly;
        //        var resources = asm.GetManifestResourceNames();

        //        var sb = new StringBuilder();
        //        sb.AppendLine("Localizer[\"Test\"] = " + value);
        //        sb.AppendLine();
        //        sb.AppendLine("Manifest Resources:");
        //        foreach (var r in resources)
        //            sb.AppendLine(r);

        //        return Content(sb.ToString());
        //    }
    }
}
