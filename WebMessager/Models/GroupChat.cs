using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMessager.Models;

namespace WebMessager.Models
{
    public class GroupChat
    {
        public long Id { get; set; }
        public string name { get; set; }
        public long UserId { get; set; }
        public List<User> Users { get; set; }

        public long GroupMessageId { get; set; }
        public List<GroupMessage> GroupMessages { get; set; }


    }
}
