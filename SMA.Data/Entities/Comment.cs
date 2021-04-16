using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.Data.Entities
{
    public class Comment : BaseEntity
    {
        [StringLength(255)]
        public string CommentBody { get; set; }
        [ForeignKey("UserHandle")]
        public string UserHandle { get; set; }
        [ForeignKey("PostId")]
         public string PostId { get; set; }
        [ForeignKey("ImageId")]
        public string ImageId { get; set; }


      
    }

}
