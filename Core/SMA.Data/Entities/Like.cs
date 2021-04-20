using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.Data.Entities
{
    public class Like:BaseEntity
    {

        [ForeignKey("PostId")]
        public int PostId { get; set; }

        [ForeignKey("CreatedByUserId")]
        public int CreatedByUserId { get; set; }

    }
}
