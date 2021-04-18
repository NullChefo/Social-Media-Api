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
            return _context.Users.Find(userId).ToUserDto();
        }

        public UserDto GetByUserHandle(string UserHandle)
        {
            return _context.Users.AsNoTracking().SingleOrDefault(x => x.UserHandle == UserHandle).ToUserDto();
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
