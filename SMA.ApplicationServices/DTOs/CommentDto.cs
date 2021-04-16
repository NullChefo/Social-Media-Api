using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class CommentDto
    {
        public int CommentId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public string CommentBody { get; set; }
        public string UserHandle { get; set; }
        public int PostId { get; set; }






    }
}
