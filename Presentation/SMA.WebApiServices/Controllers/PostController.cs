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
 // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostManagementService _service = new PostManagementService();



        
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

    
        [HttpGet, Route("/api/Post/GetByPostBody/{postbody}")]
        public ActionResult Get(string postbody)
        {

            if (_service.GetByPostBody(postbody) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_service.GetByPostBody(postbody));
            }
        }

        
        [HttpGet, Route("/api/Post/{id}")]
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

        [HttpPost, Route("/api/Post")]
        public ActionResult CreatePost(PostDto postDto)
        {
            return Ok(_service.Save(postDto));

        }

        [HttpDelete, Route("/api/Post/{id}")]
        public ActionResult Delete(int id)
        {

            return Ok(_service.Delete(id));

        }
      

    }

}




