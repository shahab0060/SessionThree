using System;
using System.Collections.Generic;

namespace SessionThree.Model
{
    public class User
    {
        public long UserId { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int InsuranceNumber { get; set; }

        public string FullName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public ICollection<InsuranceRequest> InsuranceRequests { get; set; }

        public ICollection<Notification> Notifications { get; set; }

    }
}
