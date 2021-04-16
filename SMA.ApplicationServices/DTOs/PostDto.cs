using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class PostDto
    {


        public int PostId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public string PostBody { get; set; }
        public int    CommentCount { get; set; }
       
        public int LikeCount { get; set; }
        
        public UserDto UserHandle { get; set; }




    }
}
