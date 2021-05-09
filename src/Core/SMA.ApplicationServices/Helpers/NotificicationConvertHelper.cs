using SMA.ApplicationServices.DTOs;
using SMA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SMA.ApplicationServices.Helpers
{
    public static class NotificicationConvertHelper
    {
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
                        Type = notificationDto.Type,
                        CreatedOn = notificationDto.CreatedOn,
                        UpdatedOn = notificationDto.UpdatedOn,
                        UpdatedBy = notificationDto.UpdatedBy
        
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
                        Type = notification.Type,
                        CreatedOn = notification.CreatedOn,
                        UpdatedOn = notification.UpdatedOn,
                        UpdatedBy = notification.UpdatedBy
                    };
                }
        
                public static IEnumerable<NotificationDto> ToNotificationDtos(this IEnumerable<Notification> notifications)
                {
                    return notifications.Select(x => x.ToNotificationDto());
                }
        
        
        
                #endregion
    }
}