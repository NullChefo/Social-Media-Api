using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMA.ApplicationServices.ManagementServices;
using SMA.ApplicationServices.DTOs;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
//using Microsoft.AspNetCore.Authorization;

namespace SMA.WebApiServices.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManagementService _service = new UserManagementService();

        //      [Authorize]
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_service.GetAll());
        }

        //     [Authorize]
        [HttpGet, Route("/api/User/GetByEmail/{email}")]
        public ActionResult GetByEmail(string email)
        {
            dynamic i = _service.GetByEmail(email);
            if (i == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(i);
            }
        }

        //      [Authorize]
        [HttpGet, Route("/api/User/GetUserIdByEmail/{email}")]
        public ActionResult GetUserIdByEmail(string email)
        {
            dynamic i = _service.GetUserIdByEmail(email);
            if (i == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(i);
            }
        }

        //     [Authorize]
        [HttpGet, Route("/api/User/PassLoginInfo/{email}&{password}")]
        public ActionResult PassLoginInfo(string email, string password)
        {
            dynamic i = _service.PassLoginInfo(email, password);
            if (i == null)
            {
                return NotFound();
            }
            else
            {
                var tokenString = GenerateJSONWebToken();  // !!!!!!!!
                return Ok(tokenString);
            }

        }

        //      [Authorize]
        [HttpGet, Route("/api/User/GetByUserIdTheFullNameOfUser/{id}")]
        public ActionResult GetByIdTheFullNameOfUser(int id)
        {
            dynamic i = _service.GetByUserIdTheFullNameOfUser(id);
            if (i == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(i);
            }
        }



        //    [Authorize]
        [HttpGet, Route("/api/User/{id}")]
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

        [HttpPost, Route("/api/User/")]
        public ActionResult CreateUser(UserDto userDto)
        {

            return Ok(_service.Save(userDto));

        }


        //       [Authorize]
        [HttpPost, Route("/api/User/Edit/")]
        public ActionResult Edit(UserDto userDto)
        {
            return Ok(_service.Save(userDto));
        }

        //       [Authorize]
        [HttpGet, Route("/api/User/Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Ok(_service.Edit(id));
        }



        //       [Authorize]
        [HttpDelete, Route("/api/User/{id}")]
        public ActionResult Delete(int id)
        {

            return Ok(_service.Delete(id));

        }



        private string GenerateJSONWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond007"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "#TODO Placle Requared data here",
                audience: "#TODO Placle Requared data here",
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }

}
