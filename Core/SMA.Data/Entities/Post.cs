using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.Data.Entities
{
    public class Post : BaseEntity
    {
        [StringLength(300)]
        public string PostBody { get; set; }

        public int CommentCount { get; set; }
        public int LikeCount { get; set; }

        [ForeignKey("CreatedByUserId")]
        public int CreatedByUserId { get; set; }
      


    }
}
