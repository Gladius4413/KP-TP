using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMessager.Models;
using WebMessager.SignalrModels;

namespace WebMessager.Server
{
    public class ChatHub : Hub
    {
        public async Task Send(MessageInfo mesInf)
        {
            await Clients.Others.SendAsync("Receive", $"Добавлено: {mesInf.Text} в {mesInf.Date}");

        }
    }
}