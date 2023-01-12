using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMessager.Models;
using WebMessager.ViewModels;

namespace WebMessager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MessagerContext db;

        public HomeController(ILogger<HomeController> logger, MessagerContext context)
        {
            _logger = logger;
            db = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        
        public IActionResult Messages(long userId, string connectionId)
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
