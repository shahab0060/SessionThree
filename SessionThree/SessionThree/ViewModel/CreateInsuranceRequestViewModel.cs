using System;
using System.Collections.Generic;
using System.Text;

namespace SessionThree.ViewModel
{
    public class CreateInsuranceRequestViewModel
    {
        public string Description { get; set; }

        public string ImageName { get; set; }

        public List<long> Hospitals { get; set; }
    }
}
