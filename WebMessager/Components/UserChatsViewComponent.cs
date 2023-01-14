using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMessager.Models;
using WebMessager.ViewModels;

namespace WebMessager.ViewComponents
{
    public class UserChatsViewComponent : ViewComponent
    {
        private readonly MessagerContext context;

        public  UserChatsViewComponent(MessagerContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var users = await context.User.Where(x => x.Id != currentUserId).ToListAsync();
            var model = new UserChatsViewModel();
            model.Chats = users.Select(x => new ChatViewModel() {UserId = x.Id, UserName = x.Name, Messages = new List<PrivateMessageViewModel> { } }).ToList();
            return View(model);

        }
    }
}
