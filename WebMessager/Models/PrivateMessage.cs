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


        public long UserFromId { get; set; }
        public User UserFrom { get; set; }


        public long UserToId { get; set; }
        public User UserTo { get; set; }


    }
}
