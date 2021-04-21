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

        // GET: Posts
        public ActionResult Index()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.GetStringAsync("").Result;
                var VMs = JsonConvert.DeserializeObject<IEnumerable<PostVM>>(response);

                return View(VMs);
            }
        }
            [HttpGet]
            ActionResult Create()
            { return View(); }

            [HttpPost]
            [ValidateAntiForgeryToken]
            ActionResult Create(PostVM vm)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = url;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var stringVm = JsonConvert.SerializeObject(vm);
                    var encodingVM = System.Text.Encoding.UTF8.GetBytes(stringVm);
                    var content = new ByteArrayContent(encodingVM);
                    content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                    var response = httpClient.PostAsync("", content).Result;
                }

                return RedirectToAction("Index");
            }

            [HttpGet]
            ActionResult Delete(int id)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = url;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = httpClient.GetStringAsync(url + "/" + id).Result;
                    var VM = JsonConvert.DeserializeObject<PostVM>(response);

                    return View(VM);
                }
            }

            [HttpPost, ActionName("Delete")]
            ActionResult DeleteComfirm(int id)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = url;
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = httpClient.DeleteAsync(url + "/" + id).Result;

                    return RedirectToAction("Index");
                }
            }
        }
    
}


