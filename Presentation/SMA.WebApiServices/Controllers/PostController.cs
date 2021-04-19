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
    public class PostController : ControllerBase
    {
        private readonly PostManagementService _service = new PostManagementService();



        [HttpGet, Route("/api/post/get/{id}")]
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
        [HttpPost, Route("/api/post/create")]
        public ActionResult CreatePost(PostDto postDto)
        {
            return Ok(_service.Save(postDto));

        }

        [HttpDelete, Route("/api/post/delete/{id}")]
        public ActionResult Delete(int id)
        {
           
                return Ok(_service.Delete(id));
            


        }
        [HttpPatch, Route("/api/post/edit")]
        public ActionResult EditPost(PostDto dto)
        {
            return Ok(_service.Edit(dto));
        }


    }


}




