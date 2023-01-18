using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMessager.ViewModels
{
    public class GroupMessageViewModel
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public long FromId { get; set; }
        public long ToId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
