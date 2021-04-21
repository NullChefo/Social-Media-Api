using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public string CommentBody { get; set; } = "";

        public int? PostId { get; set; }
        public int? ImageId { get; set; }
        public uint LikeCount { get; set; } = 0;
        public uint CommentCount { get; set; } = 0;






    }
}
