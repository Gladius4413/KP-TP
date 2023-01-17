using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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
        public IActionResult Friend()
        {
            return View();
        }

        [Authorize]
        [Route("Home/Messages/{userId}")]
        public IActionResult Messages(long userId)
        {

            var user = db.User.First(x => x.Id == userId);
            var currentUserId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var Messages = db.PrivateMessage.Where(x =>
                    (x.UserFromId == userId && x.UserToId == currentUserId) || (x.UserFromId == currentUserId && x.UserToId == userId)).Select(x => new PrivateMessageViewModel { Date = x.Date, From = x.UserFrom.Name, FromId = x.UserFromId, Text = x.Text, To = x.UserTo.Name, ToId = x.UserToId }).ToList();
            return View(new ChatViewModel
            {
                UserId = user.Id,
                Messages = Messages

            });

        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
