


using SMA.ApplicationServices.DTOs;
using SMA.Data.Entities;
using System.Collections.Generic;
using System.Linq;

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
                UserHandle = userDto.Handle
            };
        }

        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                UserId = user.Id,
                CreatedBy = user.CreatedBy,
                CreatedOn = user.CreatedOn,
                UpdatedBy = user.UpdatedBy,
                UpdatedOn = user.UpdatedOn,

                Handle = user.UserHandle,
                FirstName = user.FirstName,
                MidleName = user.MidleName,
                LastName = user.LastName,
                ImageId = user.ImageId,
                Location = user.Location,
                Website = user.Website,
                Bio = user.Bio,
                IsActive = user.IsActive
            };
        }

        public static IEnumerable<UserDto> ToUserDtos(this IEnumerable<User> user)
        {
            return user.Select(x => x.ToUserDto());
        }




        #endregion
    }
}
