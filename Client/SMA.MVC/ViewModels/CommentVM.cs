using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.MVC.ViewModels
{
    public class CommentVM
    {
        public int CommentId { get; set; }
        public int CreatedByUserId { get; set; }
        public string CommentBody { get; set; } = "";
        public int? PostId { get; set; }

        public DateTime? CreatedOn { get; set; } 
        public DateTime? UpdatedOn { get; set; } 
        public int UpdatedBy { get; set; } 



    }




}
