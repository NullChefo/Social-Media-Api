using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMA.ApplicationServices.ManagementServices;
using SMA.ApplicationServices.DTOs;


namespace SMA.WebApiServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManagementService _service = new UserManagementService();


        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }


        [HttpGet, Route("/api/User/GetByEmail/{email}")]
        public ActionResult GetByEmail(string email)
        {

            if (_service.GetByEmail(email) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_service.GetByEmail(email));
            }
        }
        [HttpGet, Route("/api/User/PassLoginInfo/{email}/{password}")]
        public ActionResult PassLoginInfo(string email,string password)
        {
            if (_service.PassLoginInfo(email,password) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_service.PassLoginInfo(email, password));
            }

        }
       

        [HttpGet, Route("/api/User/{id}")]
        public ActionResult GetById(int id)
        {

            if (_service.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_service.GetById(id));
            }
        }

        [HttpPost, Route("/api/User/")]
        public ActionResult CreateUser(UserDto userDto)
        {

            return Ok(_service.Save(userDto));

        }

        [HttpDelete, Route("/api/User/{id}")]
        public ActionResult Delete(int id)
        {
            
                return Ok(_service.Delete(id));
            


        }


    }

}