using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.DTOs
{
    public class UserDto
    {

        public int UserId { get; set; }
       
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }

        public string FirstName { get; set; }
        public string MidleName { get; set; }
        public string LastName { get; set; }
        public int ImageId { get; set; }
        public string Location { get; set; }
        public string Website { get; set; }
        public string Bio { get; set; }

        public DateTime? CreatedOn { get; set; } = null;
        public DateTime? UpdatedOn { get; set; } = null;
        public int UpdatedBy { get; set; } = 0;

    }
}
