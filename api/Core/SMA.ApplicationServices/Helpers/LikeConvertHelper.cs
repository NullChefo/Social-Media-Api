using SMA.ApplicationServices.DTOs;
using SMA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.Helpers
{
    public static class LikeConvertHelper
    {
          #region Like methods
        
                public static Like ToLikeEntity(this LikeDto likeDto)
                {
                    return new Like
                    {
                        Id = likeDto.LikeId,
                        PostId = likeDto.PostId,
                        CreatedByUserId = likeDto.CreatedByUserId,
                        CreatedOn = likeDto.CreatedOn,
                        UpdatedOn = likeDto.UpdatedOn,
                        UpdatedBy = likeDto.UpdatedBy
                    };
                }
        
                public static LikeDto ToLikeDto(this Like like)
                {
                    return new LikeDto
                    {
                        LikeId = like.Id,
                        PostId = like.PostId,
                        CreatedByUserId = like.CreatedByUserId,
                        CreatedOn = like.CreatedOn,
                        UpdatedOn = like.UpdatedOn,
                        UpdatedBy = like.UpdatedBy
        
                    };
                }
        
                public static IEnumerable<LikeDto> ToLikeDtos(this IEnumerable<Like> like)
                {
                    return like.Select(x => x.ToLikeDto());
                }
        
        
        
                #endregion
    }
}