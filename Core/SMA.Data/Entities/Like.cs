using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.Data.Entities
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("PostId")]
        public int PostId { get; set; }

        [ForeignKey("UserId")]
        public int CreatedByUserId { get; set; }

    }
}
