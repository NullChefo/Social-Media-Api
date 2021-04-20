using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class LikeVM
    {
        public int LikeId { get; set; }
        public int PostID { get; set; }
        public int UserId { get; set; }
    }
}
