using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMessager.Models;

namespace WebMessager.ViewModels
{
    public class GroupChatViewModel
    {
        public string Name { get; set; }
        public long NumberOfChat { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public List<GroupMessageViewModel> GroupMessages { get; set; }


    }
}
