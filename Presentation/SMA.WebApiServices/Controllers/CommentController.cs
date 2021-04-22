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


        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }


        [HttpGet, Route("/api/Comment/GetByPostId/{id}")]
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


        [HttpGet, Route("/api/Comment/GetByCommentsCountByPostId/{body}")]
        public ActionResult GetByCommentsCountByPostId(int id)
        {

            if (_service.GetByCommentsCountByPostId(id) == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(_service.GetByCommentsCountByPostId(id));
            }
        }


        [HttpGet, Route("/api/Comment/{id}")]
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
        [HttpPost, Route("/api/Comment")]
        public ActionResult CreateUser(CommentDto commentDto)
        {
            return Ok(_service.Save(commentDto));

        }

        [HttpDelete, Route("/api/Comment/{id}")]
        public ActionResult Delete(int id)
        {
            
            return Ok(_service.Delete(id));
            
        }

        

    }


}
