using SMA.ApplicationServices.DTOs;
using SMA.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.Helpers
{
    public static class NotificationConvertHelper
    {
        #region Notification method

        public static Notification ToNotificationEntity(this NotificationDto notificationDto)
        {
            return new Notification
            {
                Id = notificationDto.NotificationId


            };
        }

        public static NotificationDto ToNotificationDto(this Notification notification)
        {
            return new NotificationDto
            {
                NotificationId = notification.Id,
                IsRead = notification.IsRead,
                Recipient = notification.Recipient,
                PostId = notification.PostId,
                Sender = notification.Sender,
                Type = notification.Type
            };
        }

        public static IEnumerable<NotificationDto> ToNotificationDtos(this IEnumerable<Notification> notifications)
        {
            return notifications.Select(x => x.ToNotificationDto());
        }



        #endregion
    }
}
