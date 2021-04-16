using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class LikeDto
    {
        public int LikeId { get; set; }
        public int PostID { get; set; }
        public string UserHandle { get; set; }
    }
}
