

using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;

        private ILogger<HomeController> logger;
        public HomeController(UptimeService up, ILogger<HomeController> log)
        {
            logger = log;
            uptime = up;
        }
        public ViewResult Index(bool throwException = false)
        {
            logger.LogDebug($"Handled {Request.Path} at uptime {uptime.Uptime}");
            if (throwException)
            {
                throw new System.NullReferenceException();
            }
            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the Index Action",
                ["Uptime"] = $"{uptime.Uptime} ms"
            });
        }

        public ViewResult Error() => View(nameof(Index),
        new Dictionary<string, string>
        {
            ["Message"] = "This is the Error action"
        });
    }
}