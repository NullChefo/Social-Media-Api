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


        public UserDto GetByEmail(string Email)
        {
            return _context.Users.AsNoTracking().SingleOrDefault(x => x.UserEmail == Email).ToUserDto();
        }

        public UserDto PassLoginInfo(string Email,string Password)
        {
            return _context.Users.AsNoTracking().SingleOrDefault(x => x.UserEmail == Email && x.UserPassword == Password).ToUserDto();

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
