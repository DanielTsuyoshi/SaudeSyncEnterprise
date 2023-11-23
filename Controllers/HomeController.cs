using DermaHelp.Models;
using Microsoft.AspNetCore.Mvc;

namespace SaudeSync.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Welcome to SaudeSync";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Title"] = "About SaudeSync";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact SaudeSync";
            return View();
        }
    }
}
