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
    public class CommentController : ControllerBase
    {
        private readonly CommentManagementService _service = new CommentManagementService();


        [HttpGet, Route("api/comment")]
        public ActionResult Get()
        {
            return Ok(_service.GetAll());
        }




        [HttpGet, Route("/api/comment/get/{id}")]
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
        [HttpPost, Route("/api/comment/create")]
        public ActionResult CreateUser(CommentDto commentDto)
        {
            return Ok(_service.Save(commentDto));

        }

        [HttpDelete, Route("/api/comment/delete/{id}")]
        public ActionResult Delete(int id)
        {
            
            return Ok(_service.Delete(id));
            
        }

        

    }


}
