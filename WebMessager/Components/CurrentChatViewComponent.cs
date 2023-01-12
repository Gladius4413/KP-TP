using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMessager.Models;
using WebMessager.ViewModels;

namespace WebMessager.Components
{
    public class CurrentChatViewComponent : ViewComponent
    {
        private readonly MessagerContext context;

        //public UserChatsViewComponent(MessagerContext context)
        //{
        //    this.context = context;
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
      
            var model = new CurrentChatViewModel();
            model.Messages = new List<PrivateMessageViewModel>() { new PrivateMessageViewModel() { Text = "123123", Date = DateTime.Now } };



            return View(model);

        }
    }
}
