using System;
using System.Collections.Generic;
using System.Text;

namespace SessionThree.Model
{
    public class HospitalSelectedInsuranceRequest
    {
        public long HospitalSelectedInsuranceRequestId { get; set; }

        public long HospitalId { get; set; }

        public long InsuranceRequestId { get; set; }

        public Hospital Hospital { get; set; }

        public InsuranceRequest InsuranceRequest { get; set; }

    }
}
