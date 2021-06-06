using Microsoft.EntityFrameworkCore;
using SMA.ApplicationServices.DTOs;
using SMA.ApplicationServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.ManagementServices
{
    public class UserManagementService : BaseManagementService
    {
        public IEnumerable<UserDto> GetAll()
        {
            return _context.Users.AsNoTracking().AsEnumerable().ToUserDtos();
        }

        public UserDto GetById(int? userId)
        {
            return _context.Users.AsNoTracking().SingleOrDefault(x => x.Id == userId).ToUserDto();
        }


      public string GetByUserIdTheFullNameOfUser(int id)
        {

            UserDto user = _context.Users.AsNoTracking().SingleOrDefault(x => x.Id == id).ToUserDto();
            string UserFullName = user.FirstName + " " + user.MidleName + " " + user.LastName  ;

            return UserFullName;

        }


        public UserDto GetByEmail(string Email)
        {

            return _context.Users.AsNoTracking().SingleOrDefault(x => x.UserEmail == Email).ToUserDto();
        }

        public int GetUserIdByEmail(string Email)
        {
            UserDto user = _context.Users.AsNoTracking().SingleOrDefault(x => x.UserEmail == Email).ToUserDto();
           int UserId = user.UserId;
           return UserId;
        }


        public UserDto Login(string email,string password)
        {
            return _context.Users.AsNoTracking().SingleOrDefault(x => x.UserEmail == email && x.UserPassword == password).ToUserDto();

        }


        public int Save(UserDto userDto)
        {
            try
            {
                _context.Users.Add(userDto.ToUserEntity());
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        public UserDto Edit(int id)
        {
            return _context.Users.AsNoTracking().SingleOrDefault(x => x.Id == id).ToUserDto();

        }



        public int Delete(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                if (user == null)
                    return -1;

                _context.Users.Remove(user);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }


  



    }
}
