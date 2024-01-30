using System;
using System.Collections.Generic;
using System.Text;

namespace SessionThree.Model
{
    public class Hospital
    {
        public long HospitalId { get; set; }

        public string City { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string Type { get; set; }

        public ICollection<HospitalSelectedInsuranceRequest> InsuranceRequests { get; set; }

    }
}
