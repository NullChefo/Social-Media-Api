using SMA.ApplicationServices.DTOs;
using SMA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.Helpers
{
    public static class ConvertHelper
    {
        #region Comment methods

        public static Comment ToCommentEntity(this CommentDto commentDto)
        {
            return new Comment
            {
                Id = commentDto.CommentId,
                CreatedByUserId = commentDto.CreatedByUserId,
                CreatedOn = commentDto.CreatedOn,
                UpdatedOn = commentDto.UpdatedOn,


                CommentBody = commentDto.CommentBody,
                PostId = commentDto.PostId,
                UserHandle = commentDto.UserHandle,
                ImageId = commentDto.ImageId,
                CommentCount = commentDto.CommentCount,
                LikeCount = commentDto.LikeCount
            };
        }

        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                CommentId = comment.Id,
                CreatedByUserId = comment.CreatedByUserId,
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

        #region Image methods

        public static Image ToImageEntity(this ImageDto imageDto)
        {
            return new Image
            {
                Id = imageDto.ImageId,
                CreatedByUserId = imageDto.CreatedByUserId,
                CreatedOn = imageDto.CreatedOn,
                UpdatedOn = imageDto.UpdatedOn,
                ImageUrl = imageDto.ImageUrl,

            };
        }

        public static ImageDto ToImageDto(this Image image)
        {
            return new ImageDto
            {
                ImageId = image.Id,
                CreatedByUserId = image.CreatedByUserId,
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

        #region Like methods

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

        #region Notification methods

        public static Notification ToNotificationEntity(this NotificationDto notificationDto)
        {
            return new Notification
            {
                Id = notificationDto.NotificationId,
                IsRead = notificationDto.IsRead,
                RecipientUserId = notificationDto.RecipientUserId,
                PostId = notificationDto.PostId,
                SenderUserId = notificationDto.SenderUserId,
                Type = notificationDto.Type

            };
        }

        public static NotificationDto ToNotificationDto(this Notification notification)
        {
            return new NotificationDto
            {
                NotificationId = notification.Id,
                IsRead = notification.IsRead,
                RecipientUserId = notification.RecipientUserId,
                PostId = notification.PostId,
                SenderUserId = notification.SenderUserId,
                Type = notification.Type
            };
        }

        public static IEnumerable<NotificationDto> ToNotificationDtos(this IEnumerable<Notification> notifications)
        {
            return notifications.Select(x => x.ToNotificationDto());
        }



        #endregion

        #region Post methods

        public static Post ToPostEntity(this PostDto postDto)
        {
            return new Post
            {
                Id = postDto.PostId,
                UserHandle = postDto.UserHandle,
                CreatedByUserId = postDto.CreatedByUserId,
                CreatedOn = postDto.CreatedOn,
                UpdatedOn = postDto.UpdatedOn,
                PostBody = postDto.PostBody,
                CommentCount = postDto.CommentCount,
                LikeCount = postDto.LikeCount
                
            };
        }

        public static PostDto ToPostDto(this Post post)
        {
            return new PostDto
            {
                PostId = post.Id,
                CreatedByUserId = post.CreatedByUserId,
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

        #region User methods
        public static User ToUserEntity(this UserDto userDto)
        {
            return new User
            {
                Id = userDto.UserId,
                CreatedByUserId = userDto.CreatedByUserId,
                CreatedOn = userDto.CreatedOn,
                UpdatedByUserId = userDto.UpdatedByUserId,
                UpdatedOn = userDto.UpdatedOn,

                UserHandle = userDto.Handle,
                FirstName = userDto.FirstName,
                MidleName = userDto.MidleName,
                LastName = userDto.LastName,
                ImageId = userDto.ImageId,
                Location = userDto.Location,
                Website = userDto.Website,
                Bio = userDto.Bio,
                IsActive = userDto.IsActive

            };
        }

        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                UserId = user.Id,
                CreatedByUserId = user.CreatedByUserId,
                CreatedOn = user.CreatedOn,
                UpdatedByUserId = user.UpdatedByUserId,
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
