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
    public class NotificationController : ControllerBase
    {
        private readonly NotificationManagementService _service = new NotificationManagementService();



        [HttpGet, Route("api/notification")]
        public ActionResult Get()
        {
            return Ok(_service.GetAll());
        }



        [HttpGet, Route("/api/notification/get/{id}")]
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
        [HttpPost, Route("/api/notification/create")]
        public ActionResult CreateUser(NotificationDto notificationDto)
        {
            return Ok(_service.Save(notificationDto));

        }

        [HttpDelete, Route("/api/notification/delete/{id}")]
        public ActionResult Delete(int id)
        { 
                return Ok(_service.Delete(id));
            

        }



        

    }



}

