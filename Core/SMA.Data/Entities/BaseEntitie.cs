using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.Data.Entities
{
    public class BaseEntitie
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; } = null;
   
        public DateTime? UpdatedOn { get; set; } = null;
        public int UpdatedBy { get; set; } = 0;

    }
}
