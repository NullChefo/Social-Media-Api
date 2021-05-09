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
          #region Comment methods
        
                public static Comment ToCommentEntity(this CommentDto commentDto)
                {
                    return new Comment
                    {
                        Id = commentDto.CommentId,
                        CreatedByUserId = commentDto.CreatedByUserId,
                        CommentBody = commentDto.CommentBody,
                        PostId = commentDto.PostId,
                        CreatedOn= commentDto.CreatedOn,
                        UpdatedOn = commentDto.UpdatedOn,
                        UpdatedBy = commentDto.UpdatedBy
                       
                       
                    };
                }
        
                public static CommentDto ToCommentDto(this Comment comment)
                {
                    return new CommentDto
                    {
                        CommentId = comment.Id,
                        CreatedByUserId = comment.CreatedByUserId,
                        CommentBody = comment.CommentBody,
                        PostId = comment.PostId,
                        CreatedOn = comment.CreatedOn,
                        UpdatedOn = comment.UpdatedOn,
                        UpdatedBy = comment.UpdatedBy
        
                    };
                }
        
                public static IEnumerable<CommentDto> ToCommentDtos(this IEnumerable<Comment> comments)
                {
                    return comments.Select(x => x.ToCommentDto());
                }
        
        
        
                #endregion
    }
}