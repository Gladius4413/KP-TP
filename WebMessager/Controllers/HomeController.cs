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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            model.Chats = new List<ChatViewModel> { new ChatViewModel { UserName = "Marv", ConnectionId = "", Messages = new List<PrivateMessageViewModel> { new PrivateMessageViewModel { Date = DateTime.Now.AddDays(-1), Text = "123" } } } };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Messages(long userId, string connectionId)
        {
            var model = new IndexViewModel();
            model.Chats = new List<ChatViewModel> { new ChatViewModel { UserName = "Marv",  UserId = userId, ConnectionId = connectionId, Messages = new List<PrivateMessageViewModel> { new PrivateMessageViewModel { Date = DateTime.Now.AddDays(-1), Text = "123" } } } };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
