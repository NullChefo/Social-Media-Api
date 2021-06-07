using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }
       
        public bool IsRead { get; set; }
        public int RecipientUserId { get; set; }

        public int PostId { get; set; }
        public int SenderUserId { get; set; }
        public string Type { get; set; }

        public DateTime? CreatedOn { get; set; } = null;
        public DateTime? UpdatedOn { get; set; } = null;
        public int UpdatedBy { get; set; } = 0;


    }
}
