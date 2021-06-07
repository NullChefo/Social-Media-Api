using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace SMA.MVC.ViewModels
{
    public class NotificationVM
    {


        [JsonProperty("notificationId")]
        public int NotificationId { get; set; }
        public bool IsRead { get; set; }
        public int RecipientUserId { get; set; }

        public int PostId { get; set; }
        public int SenderUserId { get; set; }
        public string Type { get; set; }

        public DateTime? CreatedOn { get; set; } 
        public DateTime? UpdatedOn { get; set; } 
        public int UpdatedBy { get; set; }



        private readonly Uri userUrl = new Uri("https://localhost:44321/api/User");
        public async Task<string> GetByUserIdTheFullNameOfUserAsync(int id)
        {
            
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = userUrl;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                  
                    var response = await httpClient.GetStringAsync(userUrl + "/" + "GetByUserIdTheFullNameOfUser" + "?" + id);
                    if (response == null) return " ";


                    return response;
                }
                catch (Exception e)
                {
                    return "0";

                }
            }

        }









    }
}
