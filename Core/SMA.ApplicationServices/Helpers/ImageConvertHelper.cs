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
         #region Image methods
        
                public static Image ToImageEntity(this ImageDto imageDto)
                {
                    return new Image
                    {
                        Id = imageDto.ImageId,
                        CreatedByUserId = imageDto.CreatedByUserId,
                        ImageUrl = imageDto.ImageUrl,
                        CreatedOn = imageDto.CreatedOn,
                        UpdatedOn=imageDto.UpdatedOn,
                        UpdatedBy=imageDto.UpdatedBy
        
                    };
                }
        
                public static ImageDto ToImageDto(this Image image)
                {
                    return new ImageDto
                    {
                        ImageId = image.Id,
                        CreatedByUserId = image.CreatedByUserId,
                        ImageUrl = image.ImageUrl,
                        CreatedOn = image.CreatedOn,
                        UpdatedOn = image.UpdatedOn,
                        UpdatedBy = image.UpdatedBy
                    };
                }
        
                public static IEnumerable<ImageDto> ToImageDtos(this IEnumerable<Image> image)
                {
                    return image.Select(x => x.ToImageDto());
                }
        
        
        
                #endregion
    }
}