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
                CommentBody = commentDto.CommentBody,
                PostId = commentDto.PostId
               
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
                ImageUrl = imageDto.ImageUrl,
                CreatedOn = imageDto.CreatedOn,
                UpdatedOn=imageDto.UpdatedOn

            };
        }

        public static ImageDto ToImageDto(this Image image)
        {
            return new ImageDto
            {
                ImageId = image.Id,
                CreatedByUserId = image.CreatedByUserId,
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
                Id = likeDto.LikeId,
                PostId = likeDto.PostId,
                CreatedByUserId = likeDto.CreatedByUserId
            };
        }

        public static LikeDto ToLikeDto(this Like like)
        {
            return new LikeDto
            {
                LikeId = like.Id,
                PostId = like.PostId,
                CreatedByUserId = like.CreatedByUserId

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
                CreatedByUserId = postDto.CreatedByUserId,
               
                PostBody = postDto.PostBody,
                CommentCount = postDto.CommentCount,
                LikeCount = postDto.LikeCount,
                ImageId = postDto.ImageId

            };
        }

        public static PostDto ToPostDto(this Post post)
        {
            return new PostDto
            {
                PostId = post.Id,
                CreatedByUserId = post.CreatedByUserId,
                PostBody = post.PostBody,
                CommentCount = post.CommentCount,
                LikeCount = post.LikeCount,
                ImageId=post.ImageId
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

                UserEmail = userDto.UserEmail,
                UserPassword = userDto.UserPassword,

                FirstName = userDto.FirstName,
                MidleName = userDto.MidleName,
                LastName = userDto.LastName,
                ImageId = userDto.ImageId,
                Location = userDto.Location,
                Website = userDto.Website,
                Bio = userDto.Bio
                
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
                Bio = user.Bio
                
            };
        }

        public static IEnumerable<UserDto> ToUserDtos(this IEnumerable<User> user)
        {
            return user.Select(x => x.ToUserDto());
        }



        #endregion

    }




}
