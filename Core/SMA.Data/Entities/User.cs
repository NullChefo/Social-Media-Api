using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMA.Data.Entities
{
    public class User 

    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [Display(Name = "Email")]
        [StringLength(60)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "password")]
        [StringLength(60)]
        public string UserPassword { get; set; }


        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First Name")]
        [StringLength(40)]
        public string FirstName { get; set; }
        [StringLength(40)]
        public string MidleName { get; set; } = "";
        [StringLength(40)]
        public string LastName { get; set; } 

        [ForeignKey("ImageId")]
        public int ImageId { get; set; }

        [StringLength(50)]
        public string Location { get; set; } = "";
        [StringLength(60)]
        public string Website { get; set; } = "";//nullable
        [StringLength(300)]
        public string Bio { get; set; } = "";
        

       
    }

}
