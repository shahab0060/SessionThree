using SessionThree.Context;
using SessionThree.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SessionThree.Methods
{
    public class NotificationMethod 
    {
        private readonly InsuranceDbContext _context;
        public NotificationMethod(InsuranceDbContext context)
        {
            _context = context;
        }

       public async void AddNotification(string message)
        {
            long userId = AppData.CurrentUserId;
           if (userId == 0) return;
            Notification notification = new Notification()
            {
                CreateDate = DateTime.Now,
                UserId = userId,
                Text = message,
            };
            await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
        }
    }
}
