using System;

namespace SessionThree.Model
{
    public class Notification
    {
        public long NotificationId { get; set; }

        public string Text { get; set; }

        public DateTime CreateDate { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
    }
}
