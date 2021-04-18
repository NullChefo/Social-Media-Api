using SMA.ApplicationServices.DTOs;
using SMA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.Helpers
{
    public static class ImageConvertHelper
    {
        #region Image method

        public static Image ToImageEntity(this ImageDto imageDto)
        {
            return new Image
            {
                Id = imageDto.ImageId,

            };
        }

        public static ImageDto ToImageDto(this Image image)
        {
            return new ImageDto
            {
                ImageId = image.Id,
                CreatedBy = image.CreatedBy,
                CreatedOn = image.CreatedOn,
                UpdatedOn = image.UpdatedOn,
                ImageUrl = image.ImageUrl,
            };
        }

        public static IEnumerable<ImageDto> ToImageDtos(this IEnumerable<Image> image)
        {
            return image.Select(x => x.ToImageDto());
        }



        #endregion

    }
}
