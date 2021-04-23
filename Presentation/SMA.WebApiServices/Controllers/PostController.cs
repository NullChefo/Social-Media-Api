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
            var i = _service.GetByPostBody(postbody);
            if (i == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(i);
            }
        }

        
        [HttpGet, Route("/api/Post/{id}")]
        public ActionResult GetById(int id)
        {
            var i = _service.GetById(id) ;
            if (i == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(i);
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



        //[Authorize]
        [HttpPost, Route("/api/Post/Edit/")]
        public ActionResult Edit(PostDto dto)
        {
            return Ok(_service.Save(dto));
        }

        //[Authorize]
        [HttpGet, Route("/api/Post/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Ok(_service.Edit(id));
        }



    }

}




