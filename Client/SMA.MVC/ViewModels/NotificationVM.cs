using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.MVC.ViewModels
{
    public class NotificationVM
    {

        public int NotificationId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public int RecipientUserId { get; set; }

        public int PostId { get; set; }
        public int SenderUserId { get; set; }
        public string Type { get; set; }
    }
}
