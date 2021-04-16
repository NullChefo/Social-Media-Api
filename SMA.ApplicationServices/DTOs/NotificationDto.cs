using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool IsRead { get; set; }
        public UserDto Recipient { get; set; }

        public PostDto PostId { get; set; }
      
        public UserDto Sender { get; set; }
        public string Type { get; set; }


        

    }
}
