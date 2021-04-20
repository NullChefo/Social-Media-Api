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
    public class LikeController : ControllerBase
    {
        private readonly LikeManagementService _service = new LikeManagementService();



        [HttpGet, Route("api/like")]
        public ActionResult Get()
        {
            return Ok(_service.GetAll());
        }



        [HttpGet, Route("/api/like/get/{id}")]
        public ActionResult GetByPostId(int id)
        {

            if (_service.GetByPostId(id) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_service.GetByPostId(id));
            }
        }
        [HttpPost, Route("/api/like/create")]
        public ActionResult CreateUser(LikeDto likeDto)
        {
            return Ok(_service.Save(likeDto));

        }

        [HttpDelete, Route("/api/like/delate/{id}")]
        public ActionResult Delete(int id)
        {
            
                return Ok(_service.Delete(id));
            


        }


      


    }


}
