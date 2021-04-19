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

        [HttpGet, Route("/api/user/get/{id}")]
        public ActionResult Get(int id)
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
        [HttpPost, Route("/api/user/create")]
        public ActionResult CreateUser(UserDto userDto)
        {

            return Ok(_service.Save(userDto));

        }

        [HttpDelete, Route("/api/user/delete/{id}")]
        public ActionResult Delete(int id)
        {
            if (_service.Delete(id) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_service.Delete(id));
            }


        }


        [HttpPost, Route("/api/user/edit")]
        public ActionResult EditUser(UserDto dto)
        {
            return Ok(_service.Edit(dto));
        }
    }

}