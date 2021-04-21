using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.MVC.ViewModels
{
    public class PostVM
    {


        public int PostId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public int? ImageId { get; set; }
        public string PostBody { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }

    }
}
