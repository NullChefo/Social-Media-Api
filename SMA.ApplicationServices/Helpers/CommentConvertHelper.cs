using SMA.ApplicationServices.DTOs;
using SMA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.Helpers
{
    public static class CommentConvertHelper
    {
        #region Comment method

        public static Comment ToCommentEntity(this CommentDto commentDto)
        {
            return new Comment
            {
                Id = commentDto.CommentId,
                UserHandle = commentDto.UserHandle
            };
        }

        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                CommentId = comment.Id,
                CreatedBy = comment.CreatedBy,
                CreatedOn = comment.CreatedOn,
                UpdatedOn = comment.UpdatedOn,


                CommentBody = comment.CommentBody,
                PostId = comment.PostId,
                UserHandle = comment.UserHandle,
                ImageId = comment.ImageId,
                CommentCount = comment.CommentCount,
                LikeCount = comment.LikeCount

            };
        }

        public static IEnumerable<CommentDto> ToCommentDtos(this IEnumerable<Comment> comments)
        {
            return comments.Select(x => x.ToCommentDto());
        }



        #endregion


    }
}
