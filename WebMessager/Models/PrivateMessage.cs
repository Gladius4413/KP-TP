using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMessager.Models
{
    public class PrivateMessage
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
    }
}
