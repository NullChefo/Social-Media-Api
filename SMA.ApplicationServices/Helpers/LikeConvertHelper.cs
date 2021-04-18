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
        #region Like method

        public static Like ToLikeEntity(this LikeDto likeDto)
        {
            return new Like
            {
                Id = likeDto.LikeId
            };
        }

        public static LikeDto ToLikeDto(this Like like)
        {
            return new LikeDto
            {
                LikeId = like.Id,
                PostID = like.PostId,
                UserHandle = like.UserHandle

            };
        }

        public static IEnumerable<LikeDto> ToLikeDtos(this IEnumerable<Like> like)
        {
            return like.Select(x => x.ToLikeDto());
        }



        #endregion


    }
}
