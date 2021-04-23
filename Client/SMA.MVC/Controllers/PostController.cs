using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMA.MVC.ViewModels;

namespace SMA.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly Uri url = new Uri("https://localhost:44321/api/Post");
        private readonly Uri urlImage = new Uri("https://localhost:44321/api/Image");

        // GET: Posts
        public IActionResult Index()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.GetStringAsync("").Result;
                var VMs = JsonConvert.DeserializeObject<IEnumerable<PostVM>>(response);

                return View(VMs);
            }


        }
            [HttpGet]
        public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
        public IActionResult Create(PostVM postVM)
            {
                // Create Post

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = url;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var stringVm = JsonConvert.SerializeObject(postVM);
                    var encodingVM = System.Text.Encoding.UTF8.GetBytes(stringVm);
                    var content = new ByteArrayContent(encodingVM);
                    content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var response = httpClient.PostAsync("", content).Result;
                }


                // Create Image 
                int CreateImage(ImageVM image)
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.BaseAddress = urlImage;
                        httpClient.DefaultRequestHeaders.Accept.Clear();
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        var stringVm = JsonConvert.SerializeObject(image);
                        var encodingVM = System.Text.Encoding.UTF8.GetBytes(stringVm);
                        var content = new ByteArrayContent(encodingVM);
                        content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                        var response = httpClient.PostAsync("", content).Result;

                        return 1;
                    }


                }





                return RedirectToAction("Index");
            }

            [HttpGet]
        public IActionResult Delete(int id)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = url;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = httpClient.GetStringAsync(url + "/" + id).Result;
                    var VM = JsonConvert.DeserializeObject<PostVM>(response);

                    return View(VM);
                }
            }

            [HttpPost, ActionName("Delete")]
        public IActionResult DeleteComfirm(int id)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = url;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = httpClient.DeleteAsync(url + "/" + id).Result;

                    return RedirectToAction("Index");
                }
            }
        }

    }


