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
    public class ListOfFriendsViewComponent : ViewComponent
    {
        private readonly MessagerContext context;

        public ListOfFriendsViewComponent(MessagerContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserId = int.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var users = await context.User.Where(x => x.Id != currentUserId).ToListAsync();
            var model = new IndexFriendViewModel();
            model.CurrentUserId = currentUserId;
            model.Users = users.Select(x => new UserViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
            model.Requests = context.Friend.Where(x => x.User1Id == currentUserId || x.User2Id == currentUserId).Select(fr => new FriendViewModel()
            {
                RelationshipId = fr.Id,
                FromId = fr.User1Id.Value,
                ToId = fr.User2Id.Value,
                From = context.User.First(x => x.Id == fr.User1Id).Name,
                To = context.User.First(x => x.Id == fr.User2Id).Name,
                Date = fr.Date,
                Status = (FriendStatus)fr.Status

            }).ToList();
            return View(model);

        }
    }
}
