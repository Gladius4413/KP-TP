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
                Date = DateTime.Now,
                Status = FriendStatus.Pending

            };


            db.Friend.Add(new Friend
            {
                User1Id = friendViewModel.FromId,
                User2Id = friendViewModel.ToId,
                Date = friendViewModel.Date,
                Status = (int)FriendStatus.Pending
            });
            await db.SaveChangesAsync();


            var friend = db.Friend.First(x => x.User1Id == friendViewModel.FromId && x.User2Id == friendViewModel.ToId);
            friendViewModel.RelationshipId = friend.Id;
            var connectionIds = Connections.Where(x => x.Value == request.IdTo).Select(x => x.Key).ToList();
            await Clients.Clients(connectionIds).SendAsync("ReceiveReq", friendViewModel);
        }

        public async Task ApproveRequest(long relationshipId, bool status)
        {
            var fr = db.Friend.First(fr => fr.Id == relationshipId);

            if(fr != null)
            {
                var connectionIds = Connections.Where(x => x.Value == fr.User1Id || x.Value == fr.User2Id).Select(x => x.Key).ToList();
                if (status)
                {
                    fr.Status = (int)FriendStatus.Approve;
                    db.Friend.Update(fr);
                    await db.SaveChangesAsync();
                }
                else
                {
                    fr.Status = (int)FriendStatus.Decline;
                    db.Friend.Remove(fr);
                    await db.SaveChangesAsync();
                }

                await Clients.Clients(connectionIds).SendAsync("changeRelation", new FriendViewModel()
                {
                    RelationshipId = fr.Id,
                    FromId = fr.User1Id.Value,
                    ToId = fr.User2Id.Value,
                    From = db.User.First(x => x.Id == fr.User1Id).Name,
                    To = db.User.First(x => x.Id == fr.User2Id).Name,
                    Date = fr.Date,
                    Status = (FriendStatus)fr.Status

                });
            }

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