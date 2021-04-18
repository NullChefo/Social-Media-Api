using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class UserDto
    {

        public int UserId { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }


        public string Handle { get; set; }
        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string LastName { get; set; }
        public int ImageId { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string Bio { get; set; }
        public bool IsActive { get; set; }


    }
}
