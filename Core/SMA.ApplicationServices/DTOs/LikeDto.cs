﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class LikeDto
    {
        public int LikeId { get; set; }
        public int PostId { get; set; }
        public int CreatedByUserId { get; set; }


        public DateTime? CreatedOn { get; set; } = null;
        public DateTime? UpdatedOn { get; set; } = null;
        public int UpdatedBy { get; set; } = 0;
    }
}
