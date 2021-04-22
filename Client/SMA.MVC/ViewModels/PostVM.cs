using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SMA.MVC.ViewModels
{
  

    public class PostVM
    {


        public int PostId { get; set; }
        public int CreatedByUserId { get; set; }
     

        public int? ImageId { get; set; }
        public string PostBody { get; set; }
        public int CommentCount { get; set; }
        public int LikeCount { get; set; }


        public string GetImageById(int id)
        {
            WebClient webClient = new WebClient();
            string result = webClient.DownloadString($"https://localhost:44321/api/Image/GetById/{id}");
            return result;
        }

    }

   


}
