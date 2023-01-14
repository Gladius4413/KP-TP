using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMessager.SignalrModels
{
    public class MessageInfo
    {
        public string Text { get; set; }
        public long IdFrom { get; set; }
        public long IdTo { get; set; }
        public DateTime? Date { get; set; }
    }
}
