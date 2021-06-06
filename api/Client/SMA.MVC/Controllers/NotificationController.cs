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
    public class NotificationController : Controller
    {
        private readonly Uri url = new Uri("https://localhost:44321/api/Notification");
    //    private readonly Uri urlRecipiant = new Uri("https://localhost:44321/api/Notification/GetByRecipientUserId/"+ HttpContext.Session.GetString("UserId"));

        // GET: 
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") == null) { return View(null); }
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.GetStringAsync(url + "/" + "GetByRecipientUserId" + "/" + HttpContext.Session.GetString("UserId")).Result;
                var VMs = JsonConvert.DeserializeObject<IEnumerable<NotificationVM>>(response);

                return View(VMs);
            }
        }
      
        [HttpGet]
        public IActionResult Create()
        { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NotificationVM vm)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var stringVm = JsonConvert.SerializeObject(vm);
                var encodingVM = System.Text.Encoding.UTF8.GetBytes(stringVm);
                var content = new ByteArrayContent(encodingVM);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var response = httpClient.PostAsync("", content).Result;

                return RedirectToAction("Index", "Notification");
            }

           
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
                var vm = JsonConvert.DeserializeObject<NotificationVM>(response);

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
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.DeleteAsync(url + "/" + id).Result;

                return RedirectToAction("Index", "Notification");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = httpClient.GetStringAsync(url + "/Edit/" + id).Result;
                var vm = JsonConvert.DeserializeObject<NotificationVM>(response);
                return View(vm);
            }
        }



        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NotificationVM vm)
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
                var response = httpClient.PutAsync(url + "/Edit/", content).Result;

                return RedirectToAction("Index", "Notification");
            }

        }





    }
}


