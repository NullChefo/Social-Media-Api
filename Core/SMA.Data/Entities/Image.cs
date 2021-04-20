using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.Data.Entities
{
    public class Image : BaseEntity
    {

        public string ImageUrl { get; set; }

        [ForeignKey("CreatedByUserId")]
        public int CreatedByUserId { get; set; }


    }
}
