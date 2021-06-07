using System;
using System.Collections.Generic;
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
        private readonly Uri urlImage = new Uri("https://localhost:44321/api/Image");

        // GET: Users
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
        public async Task<IActionResult> Login(UserVM userVM)
        {
            string email = userVM.UserEmail;
            string password = userVM.UserPassword;
            string token;
            string UserId;

            //Chech if it in the database
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = await httpClient.GetStringAsync(url + "/" + "Login" + "/" + email + "&" + password);
                    token = response;
                }
                catch (Exception e)
                {
                    Console.Write(e);
                    return RedirectToAction("Login", "User");
                }

            }
            HttpContext.Session.SetString("Token", token); // !!! Stores the token in sesion

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = url;
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var response = await httpClient.GetStringAsync(url + "/" + "GetUserIdByEmail" + "/" + email);
                    UserId = response;

                }
                catch (Exception e)
                {
                    Console.Write(e);
                    return RedirectToAction("Login", "User");
                }

                HttpContext.Session.SetString("UserId", UserId);// !!! Stores the UserId in sesionn


                return RedirectToAction("Index", "Home");
            }

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



            return RedirectToAction("Login", "User");
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
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("Token"));

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = httpClient.DeleteAsync(url + "/" + id).Result;

                return RedirectToAction("Index", "User");
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
                var vm = JsonConvert.DeserializeObject<UserVM>(response);
                return View(vm);
            }
        }



        [HttpPut]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserVM vm)
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

                return RedirectToAction("Index", "User");
            }



        }


    }
}

