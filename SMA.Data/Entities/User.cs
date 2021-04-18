using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMA.Data.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(60)]
        public string UserHandle { get; set; }

        [Required]
        [StringLength(40)]
        public string FirstName { get; set; }
        [StringLength(40)]
        public string MidleName { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }

        [ForeignKey("ImageId")]
        public string ImageId { get; set; }
        [StringLength(50)]
        public string Location { get; set; }
        [StringLength(60)]
        public string Website { get; set; }
        [StringLength(300)]
        public string Bio { get; set; }

        
        public bool IsActive { get; set; }



    }
}
