using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.MVC.ViewModels
{
    public class UserVM
    {

        public int UserId { get; set; }

       

        [Required(ErrorMessage = "Please enter email")]
        [Display(Name = "Email")]
        [StringLength(60)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        [StringLength(60)]
        public string UserPassword { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        [Display(Name = "First name")]
        [StringLength(60)]
        public string FirstName { get; set; }
        [Display(Name = "Midle name")]
        [StringLength(60)]
        public string MidleName { get; set; }

        [Required(ErrorMessage = "Please enter last name")]
        [Display(Name = "Last name")]
        [StringLength(60)]
        public string LastName { get; set; }
        public int? ImageId { get; set; }
       
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "Website")]
        public string Website { get; set; }
        [Display(Name = "Bio")]
        public string Bio { get; set; }

        public DateTime? CreatedOn { get; set; } 
        public DateTime? UpdatedOn { get; set; } 
        public int UpdatedBy { get; set; } 

    }
}
