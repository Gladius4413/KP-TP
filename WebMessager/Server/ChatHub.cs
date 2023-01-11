using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMessager.Server
{
    public class ChatHub : Hub
    {
        public async Task Send(string message, string userMail)
        {
            await this.Clients.All.SendAsync("Send", message, userMail);

        }
    }
}