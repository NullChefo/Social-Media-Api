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


        [HttpGet, Route("/api/Comment/GetCommentsCountByPostId/{id}")]
        public ActionResult GetCommentsCountByPostId(int id)
        {

            if (_service.GetCommentsCountByPostId(id) == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(_service.GetCommentsCountByPostId(id));
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

        //[Authorize]
        [HttpPost, Route("/api/Comment/Edit/")]
        public ActionResult Edit(CommentDto dto)
        {
            return Ok(_service.Save(dto));
        }

        //[Authorize]
        [HttpGet, Route("/api/Image/Comment/{id}")]
        public ActionResult Edit(int id)
        {
            return Ok(_service.Edit(id));
        }



    }


}
