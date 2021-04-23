


using System;
using System.Net.Http;
using System.Net.Http.Headers;
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




        private readonly Uri userUrl = new Uri("https://localhost:44321/api/User");
        private readonly Uri likeUrl = new Uri("https://localhost:44321/api/Like");
        private readonly Uri commentUrl = new Uri("https://localhost:44321/api/Comment");
        private readonly Uri imgUrl = new Uri("https://localhost:44321/api/Image");

        public int Dummu()
        {
            return 0;
        }

        public int Test(int id)
        {
            return (id);
        }


        public async Task<string> GetByUserIdTheFullNameOfUser(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = userUrl;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await httpClient.GetStringAsync(userUrl + "/" + "GetByUserIdTheFullNameOfUser" + "/" + id);
                    return response;
                }
                catch (Exception e)
                {
                    return "0";

                }
            }

        }
        public async Task<int> GetLikesCountByPostId(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = likeUrl;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await httpClient.GetStringAsync(likeUrl + "/" + "GetLikesCountByPostId" + "/" + id);


                    return Int32.Parse(response);
                }
                catch (Exception e)
                {
                    return 0;

                }
            }

        }

        public async Task<int> GetCommentsCountByPostId(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = commentUrl;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await httpClient.GetStringAsync(commentUrl + "/" + "GetCommentsCountByPostId" + "/" + id);


                    return Int32.Parse(response);
                }
                catch (Exception e)
                {
                    return 0;

                }
            }

        }



        public async Task<string> GetImagePathByImageId(int? id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = imgUrl;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await httpClient.GetStringAsync(imgUrl + "/" + "GetImagePathByImageId" + "/" + id);


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
