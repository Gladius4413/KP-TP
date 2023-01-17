using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMessager.Models;
using WebMessager.ViewModels;

namespace WebMessager.Components
{
    public class AddFriendViewComponent : ViewComponent
    {
        private readonly MessagerContext context;

        public AddFriendViewComponent(MessagerContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var users = await context.User.Where(x => x.Id != currentUserId).ToListAsync();
            var model = new IndexFriendViewModel();
            model.Requests = users.Select(x => new FriendRequestViewModel() { UserId = x.Id, UserName = x.Name, Friends = new List<FriendViewModel> { } }).ToList();
            return View(model);
            
        }
    }
}
