using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMA.MVC.ViewModels;

namespace SMA.MVC.Controllers
{
    public class UserController : Controller
    {

        private readonly Uri url = new Uri("https://localhost:44321/api/User");


        // GET: Users
        public IActionResult Index()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.GetStringAsync("").Result;
                var userVMs = JsonConvert.DeserializeObject<IEnumerable<UserVM>>(response);

                return View(userVMs);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserVM vm)
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
            return RedirectToAction("Index", "Post");
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserVM vm)
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

            return RedirectToAction("Index", "User");
        }




        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.GetStringAsync(url + "/" + id).Result;
                var vm = JsonConvert.DeserializeObject<UserVM>(response);

                return View(vm);
            }
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteComfirm(int id)
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

