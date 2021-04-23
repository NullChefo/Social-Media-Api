using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMA.ApplicationServices.ManagementServices;
using SMA.ApplicationServices.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace SMA.WebApiServices.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly LikeManagementService _service = new LikeManagementService();


        
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }


       
        [HttpGet, Route("/api/Like/{id}")]
        public ActionResult GetById(int id)
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

       
        [HttpGet, Route("/api/Like/GetByPostId/{id}")]
        public ActionResult GetByPostId(int id)
        {
            var i = _service.GetByPostId(id);
            if (i == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(i);
            }
        }
       
        [HttpGet, Route("/api/Like/GetLikesCountByPostId/{id}")]
        public ActionResult GetLikesCountByPostId(int id)
        {
            var i = _service.GetLikesCountByPostId(id);
            if (i == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(i);
            }
        }


        
        [HttpPost, Route("/api/Like")]
        public ActionResult CreateUser(LikeDto likeDto)
        {
            return Ok(_service.Save(likeDto));

        }
        
        [HttpDelete, Route("/api/Like/{id}")]
        public ActionResult Delete(int id)
        {
            
                return Ok(_service.Delete(id));
            
        }

   
        [HttpPost, Route("/api/Like/Edit/")]
        public ActionResult Edit(LikeDto dto)
        {
            return Ok(_service.Save(dto));
        }

      
        [HttpGet, Route("/api/Like/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Ok(_service.Edit(id));
        }



    }


}
