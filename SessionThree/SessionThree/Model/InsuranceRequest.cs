using System;
using System.Collections.Generic;
using System.Text;

namespace SessionThree.Model
{
    public class InsuranceRequest
    {
        public long InsuranceRequestId { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public DateTime CreateDate { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public ICollection<HospitalSelectedInsuranceRequest> Hospitals{ get; set; }

    }
}
