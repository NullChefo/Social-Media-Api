using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.Data.Entities
{
    public class Post : BaseEntitie
    {
        

        [ForeignKey("UserId")]
        public int CreatedByUserId { get; set; }

        [ForeignKey("ImageId")]
        public int? ImageId { get; set; }

        [StringLength(300)]
        public string PostBody { get; set; } = "";
       

      


    }
}
