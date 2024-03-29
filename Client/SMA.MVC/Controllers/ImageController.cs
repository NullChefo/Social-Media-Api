﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SMA.MVC.ViewModels;

namespace SMA.MVC.Controllers
{
    public class ImageController : Controller
    {

        private readonly Uri url = new Uri("https://localhost:44321/api/Image");

        // GET: Images
          public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserId") == null) { return View(null); }

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.GetStringAsync("").Result;
                var vms = JsonConvert.DeserializeObject<IEnumerable<ImageVM>>(response);

                return View(vms);
            }
        }

        [HttpGet("{id}")]
        public IEnumerable<ImageVM> GetAll(int id)
        {
            IEnumerable<ImageVM> students = null;

            using (var client = new HttpClient())

            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                client.BaseAddress = new Uri("https://localhost:44321/api/" + "Image/" + id);
                //HTTP GET
                var responseTask = client.GetAsync("Image");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ImageVM>>();
                    readTask.Wait();
                    students = readTask.Result;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    students = Enumerable.Empty<ImageVM>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return students;
        }



        [HttpGet]
        public IActionResult Create()
        { return View(); }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(LikeVM vm)
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

                return RedirectToAction("Index", "Image");
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
                var vm = JsonConvert.DeserializeObject<ImageVM>(response);

                return View(vm);
            }
        }

        [HttpPost, ActionName("Delete")]
      public  IActionResult DeleteComfirm(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.DeleteAsync(url + "/" + id).Result;

                return RedirectToAction("Index","Image");
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
                var vm = JsonConvert.DeserializeObject<ImageVM>(response);
                return View(vm);
            }
        }



        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ImageVM vm)
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

                return RedirectToAction("Index", "Image");
            }

        }




    }
}



