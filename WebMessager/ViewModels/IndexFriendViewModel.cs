using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMessager.ViewModels
{
    public class IndexFriendViewModel
    {
        public long CurrentUserId { get; set; }

        public List<UserViewModel> Users { get; set; }

        public List<FriendViewModel> Requests { get; set; }
    }
}
