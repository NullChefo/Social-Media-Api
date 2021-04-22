using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class ImageDto
    {
        public int ImageId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime? CreatedOn { get; set; } 
        public DateTime? UpdatedOn { get; set; }
        public string ImageUrl { get; set; }


    }
}
