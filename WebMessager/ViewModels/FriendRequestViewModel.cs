using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMessager.ViewModels
{
    public class FriendRequestViewModel
    {
        public string UserName { get; set; }
        public long UserId { set; get; }
        public string ConnectionId { get; set; }
        public List<FriendViewModel> Friends { get; set; }

    }
}
