using Microsoft.EntityFrameworkCore;
using SMA.ApplicationServices.DTOs;
using SMA.ApplicationServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.ManagementServices
{
    public class NotificationManagementService : BaseManagementService
    {
        public IEnumerable<NotificationDto> GetAll()
        {
            return _context.Notifications.AsNoTracking().AsEnumerable().ToNotificationDtos();
        }

        public NotificationDto GetById(int id)
        {
            return _context.Notifications.Find(id).ToNotificationDto();
        }

        public NotificationDto GetByRecipientUserId(int RecipientUserId)
        {
            return _context.Notifications.Find(RecipientUserId).ToNotificationDto();
        }

        public NotificationDto GetBySenderUserId(int SenderUserId)
        {
            return _context.Notifications.Find(SenderUserId).ToNotificationDto();
        }

        public int Save(NotificationDto notificationDto)
        {
            try
            {
                _context.Notifications.Add(notificationDto.ToNotificationEntity());
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(int id)
        {
            try
            {
                var notification = _context.Notifications.Find(id);
                if (notification == null)
                    return -1;

                _context.Notifications.Remove(notification);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

     


    }
}
