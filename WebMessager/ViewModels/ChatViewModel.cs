using System.Collections.Generic;
using WebMessager.Controllers;

namespace WebMessager.ViewModels
{
    public class ChatViewModel
    {
        public string UserName { get; set; }
        public long UserId { set; get; }
        public string ConnectionId { get; set; }
        //public List<PrivateMessageViewModel> Messages { get; set; }
        public List<ChatViewModel> Chats { get; set; }
    }
}
