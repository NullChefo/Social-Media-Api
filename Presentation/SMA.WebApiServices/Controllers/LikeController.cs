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



        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }



        [HttpGet, Route("/api/Like/{id}")]
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


        [HttpGet, Route("/api/Like/GetByPostId/{id}")]
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

        [HttpGet, Route("/api/Like/GetByLikesCountByPostId/{id}")]
        public ActionResult GetByLikesCountByPostId(int id)
        {

            if (_service.GetByLikesCountByPostId(id) == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(_service.GetByLikesCountByPostId(id));
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


      


    }


}
