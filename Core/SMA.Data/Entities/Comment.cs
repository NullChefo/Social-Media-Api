using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.Data.Entities
{
    public class Comment 
    {

        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string CommentBody { get; set; } = "";

        [ForeignKey("UserId")]
        public int CreatedByUserId { get; set; }

        [ForeignKey("PostId")]
        public int? PostId { get; set; }

    
      



    }

}
