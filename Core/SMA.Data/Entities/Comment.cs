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
        public string CommentBody { get; set; } = "";

        [ForeignKey("CreatedByUserId")]
        public int CreatedByUserId { get; set; }

        [ForeignKey("PostId")]
         public int? PostId { get; set; }

    
        [ForeignKey("ImageId")]
        public int? ImageId { get; set; }

        public uint LikeCount { get; set; } = 0;
        public uint CommentCount { get; set; } = 0;



    }

}
