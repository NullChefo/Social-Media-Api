using SMA.ApplicationServices.DTOs;
using SMA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.Helpers
{
    public static class UserConvertHelper
    {
         #region User methods
                public static User ToUserEntity(this UserDto userDto)
                {
                    return new User
                    {
                        Id = userDto.UserId,
        
                        UserEmail = userDto.UserEmail,
                        UserPassword = userDto.UserPassword,
        
                        FirstName = userDto.FirstName,
                        MidleName = userDto.MidleName,
                        LastName = userDto.LastName,
                        ImageId = userDto.ImageId,
                        Location = userDto.Location,
                        Website = userDto.Website,
                        Bio = userDto.Bio,
        
                          CreatedOn = userDto.CreatedOn,
                        UpdatedOn = userDto.UpdatedOn,
                        UpdatedBy = userDto.UpdatedBy
        
                    };
                }
        
                public static UserDto ToUserDto(this User user)
                {
                    return new UserDto
                    {
                        UserId = user.Id,
                  
                        UserEmail = user.UserEmail,
                        UserPassword = user.UserPassword,
        
                        FirstName = user.FirstName,
                        MidleName = user.MidleName,
                        LastName = user.LastName,
                        ImageId = user.ImageId,
                        Location = user.Location,
                        Website = user.Website,
                        Bio = user.Bio,
        
                        CreatedOn = user.CreatedOn,
                        UpdatedOn = user.UpdatedOn,
                        UpdatedBy = user.UpdatedBy
        
                    };
                }
        
                public static IEnumerable<UserDto> ToUserDtos(this IEnumerable<User> user)
                {
                    return user.Select(x => x.ToUserDto());
                }
        
        
        
                #endregion
    }
}