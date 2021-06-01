using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMA.ApplicationServices.ManagementServices;
using SMA.ApplicationServices.DTOs;
//using Microsoft.AspNetCore.Authorization;

namespace SMA.WebApiServices.Controllers
{
  //  [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationManagementService _service = new NotificationManagementService();


       
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }




        
        [HttpGet, Route("/api/Notification/GetByRecipientUserId/{id}")]
        public ActionResult GetByRecipientUserId(int id)
        {
            var i = _service.GetByRecipientUserId(id);
            if ( i == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(i);
            }
        }

    
        [HttpGet, Route("/api/Notification/GetBySenderUserId/{id}")]
        public ActionResult GetBySenderUserId(int id)
        {

            var i = _service.GetBySenderUserId(id);

            if ( i == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(i);
            }
        }

     
        [HttpGet, Route("/api/Notification/{id}")]
        public ActionResult Get(int id)
        {
            var i = _service.GetById(id);
            if (i == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(i);
            }
        }
     
        [HttpPost, Route("/api/Notification")]
        public ActionResult CreateUser(NotificationDto notificationDto)
        {
            return Ok(_service.Save(notificationDto));

        }
      
        [HttpDelete, Route("/api/Notification/{id}")]
        public ActionResult Delete(int id)
        { 
                return Ok(_service.Delete(id));
            

        }



        
        [HttpPut, Route("/api/Notification/Edit/")]
        public ActionResult Edit(NotificationDto dto)
        {
            return Ok(_service.Save(dto));
        }

        
        [HttpGet, Route("/api/Notification/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Ok(_service.Edit(id));
        }


    }



}

