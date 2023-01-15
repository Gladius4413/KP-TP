using System;

namespace WebMessager.ViewModels
{
    public class PrivateMessageViewModel
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public long FromId { get; set; }
        public long ToId { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}