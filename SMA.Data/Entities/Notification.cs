using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.Data.Entities
{
    public class Notification : BaseEntity
    {
        public bool IsRead { get; set; }

        public string Recipient { get; set; }

        [ForeignKey("PostId")]
        public int PostId { get; set; }
        
        public string Sender { get; set; }
        public string Type { get; set; }


    }
}
