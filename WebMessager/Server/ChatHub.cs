using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using WebMessager.Controllers;
using WebMessager.SignalrModels;
using WebMessager.ViewModels;
using WebMessager.Models;

namespace WebMessager.Server
{
    public class ChatHub : Hub
    {
        private MessagerContext db;
        public ChatHub(MessagerContext context)
        {
            db = context;
        }
        /// <summary>
        /// The dictionary
        /// </summary>
        private static Dictionary<string, long> Connections = new();

        public async Task Send(MessageInfo mesInf)
        {
            var currentUserId = Connections[Context.ConnectionId];
            var privateMessageViewModel = new PrivateMessageViewModel()
            {
                FromId = currentUserId,
                ToId = mesInf.IdTo,
                From = db.User.First(x => x.Id == currentUserId).Name,
                To = db.User.First(x => x.Id == mesInf.IdTo).Name,
                Date = DateTime.Now,
                Text = mesInf.Text
            };
            try
            {
                db.PrivateMessage.Add(new PrivateMessage { Date = privateMessageViewModel.Date, UserFromId = privateMessageViewModel.FromId, UserToId = privateMessageViewModel.ToId, Text = privateMessageViewModel.Text });
                await db.SaveChangesAsync();

            }
            catch (Exception e)
            {
                return;
            }
            var connectionIds = Connections.Where(x => x.Value == mesInf.IdTo || x.Value == currentUserId).Select(x => x.Key).ToList();
            await Clients.Clients(connectionIds).SendAsync("Receive", privateMessageViewModel);
        }

        public async Task SendFriendRequest(FriendRequestInfo request)
        {

            var currentUserId = Connections[Context.ConnectionId];


            var friendViewModel = new FriendViewModel()
            {
                FromId = currentUserId,
                ToId = request.IdTo,
                From = db.User.First(x => x.Id == currentUserId).Name,
                To = db.User.First(x => x.Id == request.IdTo).Name,
                Date = DateTime.Now

            };
            var connectionIds = Connections.Where(x => x.Value == request.IdTo || x.Value == currentUserId).Select(x => x.Key).ToList();
            await Clients.Clients(connectionIds).SendAsync("ReceiveReq", friendViewModel);



        }

        public override Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var currentUserId = int.Parse(httpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            Connections.Add(Context.ConnectionId, currentUserId);
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// Ons the disconnected using the specified exception
        /// </summary>
        /// <param name="exception">The exception</param>
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Connections.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}