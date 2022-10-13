

using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace ConfiguringApps.Controllers
{
    public class HomeController : Controller
    {
        private UptimeService uptime;
        public HomeController(UptimeService up) => uptime = up;
        public ViewResult Index() => View(new Dictionary<string, string>
        {
            ["Message"] = "This is the Index Action",
            ["Uptime"] = $"{uptime.Uptime} ms"
        });
    }
}