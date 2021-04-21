using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMA.ApplicationServices.ManagementServices;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using SMA.ApplicationServices.DTOs;

namespace SMA.WebApiServices.Controllers
{
    [Produces("application/json")]
    [Route("api/Image")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly ImageManagementService _service = new ImageManagementService();

        private readonly IWebHostEnvironment _environment;

        public ImageController(IWebHostEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }
        


        [HttpGet, Route("/api/Image/GetByCreatedByUserId/{id}")]
        public ActionResult GetByPostId(int id)
        {

            if (_service.GetByCreatedByUserId(id) == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_service.GetByCreatedByUserId(id));
            }
        }



        [HttpGet, Route("/api/Image/{id}")]
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


        #region Upload image

        [HttpPost, Route("/api/Image")]
        public async Task<IActionResult> UploadImage(List<IFormFile> files, int UserId)
        {
            ImageDto image = new ImageDto();

            try
            {

                foreach (var file in files)
                {

                    string uniqueFileName = null;

                    string uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                    //Makes unique file name + filetype
                    // #TODO Chech filename for bad file type 
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    var fileStream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(fileStream);


                    image.ImageUrl = filePath;
                    image.CreatedByUserId = UserId;
                    image.CreatedOn = DateTime.Now;

                    _service.Save(image);

                }
                return Ok();



            }
            catch
            {
                return BadRequest();
            }
        }

        #endregion

      

        [HttpDelete, Route("/api/Image/{id}")]
        public ActionResult Delete(int id)
        {
       
                return Ok(_service.Delete(id));
            
        }



       

    }
}






