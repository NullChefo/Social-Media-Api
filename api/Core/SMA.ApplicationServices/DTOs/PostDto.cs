using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class PostDto
    {


        public int PostId { get; set; }
        public int CreatedByUserId { get; set; }
  
        public string PostBody { get; set; }
        public int? ImageId { get; set; }

        public DateTime? CreatedOn { get; set; } = null;
        public DateTime? UpdatedOn { get; set; } = null;
        public int UpdatedBy { get; set; } = 0;



    }
}
