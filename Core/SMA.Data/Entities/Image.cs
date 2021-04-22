using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.Data.Entities
{
    public class Image 
    {
        [Key]
        public int Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public string ImageUrl { get; set; }

        [ForeignKey("UserId")]
        public int CreatedByUserId { get; set; }


    }
}
