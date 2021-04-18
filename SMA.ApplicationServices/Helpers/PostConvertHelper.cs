using SMA.ApplicationServices.DTOs;
using SMA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.Helpers
{
    public static class PostConvertHelper
    {
        #region Post method

        public static Post ToPostEntity(this PostDto postDto)
        {
            return new Post
            {
                Id = postDto.PostId,
                UserHandle = postDto.UserHandle
            };
        }

        public static PostDto ToPostDto(this Post post)
        {
            return new PostDto
            {
                PostId = post.Id,
                CreatedBy = post.CreatedBy,
                CreatedOn = post.CreatedOn,
                UpdatedOn = post.UpdatedOn,


                PostBody = post.PostBody,
                CommentCount = post.CommentCount,
                LikeCount = post.LikeCount,
                UserHandle = post.UserHandle
            };
        }

        public static IEnumerable<PostDto> ToPostDtos(this IEnumerable<Post> post)
        {
            return post.Select(x => x.ToPostDto());
        }



        #endregion

    }
}
